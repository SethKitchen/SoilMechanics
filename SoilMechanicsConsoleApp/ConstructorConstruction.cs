using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SoilMechanicsConsoleApp
{
    public static class ConstructorExtension
    {

        private static bool ShouldDescend(ParameterInfo param)
        {
            return param.ParameterType.IsClass && param.ParameterType != typeof(string);
        }

        public static IEnumerable<ComplexTypeNode> GetConstructs(Type t)
        {
            foreach (var ctor in t.GetConstructors())
            {
                if (ctor.IsCyclic(ShouldDescend))
                { continue; }

                var constructs = new List<ComplexTypeNode>()
        {
            new ComplexTypeNode
            {
                TotalParamerters = 0,
                Children = new List<TypeNode>(),
                ArgType = t
            }
        };

                foreach (var param in ctor.GetParameters())
                {
                    if (ShouldDescend(param))
                    {
                        constructs = GetConstructs(param.ParameterType)
                            .SelectMany(
                                childNode => constructs.Select(
                                    node =>
                                    {
                                        var newNode = (ComplexTypeNode)node.Clone();
                                        var child = (ComplexTypeNode)childNode.Clone();
                                        child.ParamName = param.Name;
                                        newNode.Children.Add(child);
                                        newNode.TotalParamerters += child.TotalParamerters;
                                        return newNode;
                                    }))
                            .ToList();
                    }
                    else
                    {
                        constructs.ForEach(node =>
                        {
                            node.Children.Add(new TypeNode
                            {
                                ArgType = param.ParameterType,
                                TotalParamerters = 1,
                                ParamName = param.Name
                            });
                            node.TotalParamerters += 1;
                        });
                    }

                }

                foreach (var construct in constructs)
                { yield return construct; }
            }
        }

        public static bool IsCyclic(
            this ConstructorInfo ctor, Func<ParameterInfo, bool> shouldDescend)
        {
            var refMatrix = new Dictionary<Type, HashSet<Type>>();

            foreach (var param in ctor.GetParameters())
            {
                if (shouldDescend(param) &&
                    IsCyclic(param.ParameterType, shouldDescend, refMatrix))
                { return true; }
            }

            return false;
        }

        private static bool IsCyclic(
            Type argType,
            Func<ParameterInfo, bool> shouldDescend,
            Dictionary<Type, HashSet<Type>> refMatrix)
        {
            foreach (var ctor in argType.GetConstructors())
            {
                foreach (var param in ctor.GetParameters())
                {
                    if (!shouldDescend(param))
                    { continue; }

                    if (refMatrix.TryGetValue(argType, out var argDeps))
                    { argDeps.Add(param.ParameterType); }
                    else
                    { refMatrix[argType] = new HashSet<Type> { param.ParameterType }; }

                    if ((refMatrix.TryGetValue(param.ParameterType, out var paramDeps) &&
                            paramDeps.Contains(argType)) ||
                        IsCyclic(param.ParameterType, shouldDescend, refMatrix))
                    { return true; }
                }
            }

            return false;
        }
    }

    public class TypeNode
    {
        public Type ArgType { get; set; }

        public int TotalParamerters { get; set; }

        public string ParamName { get; set; }

        public override string ToString()
        {
            return $"{ArgType} {ParamName}";
        }

        public virtual object Build(params object[] args)
        {
            if (args == null ||
                args.Length == 0 ||
                !ArgType.IsAssignableFrom(args[0].GetType()))
            { return default; }

            return args[0];
        }

        public virtual TypeNode Clone()
        {
            return new TypeNode
            {
                TotalParamerters = TotalParamerters,
                ArgType = ArgType,
                ParamName = ParamName
            };
        }
    }

    public class ComplexTypeNode : TypeNode
    {
        public List<TypeNode> Children { get; set; }

        public override string ToString()
        {
            var args = string.Join(
                ", ",
                Children?
                    .Select(child => child.ToString())
                    .ToArray() ?? new string[0]);

            var paramName = string.IsNullOrEmpty(ParamName)
                ? ""
                : $" {ParamName}";

            return $"{ArgType} ({args}){paramName}";
        }

        public override object Build(params object[] args)
        {
            if (args?.Length != TotalParamerters)
            { throw new ArgumentException(nameof(args)); }

            var taken = 0;
            var parameters = new List<object>();

            foreach (var child in Children)
            {
                var objs = args
                    .Skip(taken)
                    .Take(child.TotalParamerters)
                    .ToArray();
                taken += child.TotalParamerters;
                parameters.Add(child.Build(objs));
            }

            return Activator.CreateInstance(ArgType, parameters.ToArray());
        }

        public override TypeNode Clone()
        {
            return new ComplexTypeNode
            {
                ArgType = ArgType,
                TotalParamerters = TotalParamerters,
                ParamName = ParamName,
                Children = Children.Select(child => child.Clone()).ToList()
            };
        }
    }
}

