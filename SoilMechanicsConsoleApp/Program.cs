using System;
using System.Linq;
using SoilMechanicsLibrary.SpecificGravity;
using SoilMechanicsLibrary.UnitWeights;
using SoilMechanicsLibrary.Volumes;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsConsoleApp
{
    class Program
    {
        static bool PrintMainMenu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("Pick a number:");
            Console.WriteLine("1. Specific Gravities");
            Console.WriteLine("2. Unit Weights");
            Console.WriteLine("3. Volumes");
            Console.WriteLine("4. Weights");
            Console.WriteLine("5 or [else]. End Program.");
            string selection = Console.ReadLine();
            try
            {
                int numSelect = int.Parse(selection);
                switch (numSelect)
                {
                    case 1:
                        PrintSpecificGravities();
                        break;
                    case 2:
                        PrintUnitWeights();
                        break;
                    case 3:
                        PrintVolumes();
                        break;
                    case 4:
                        PrintWeights();
                        break;
                    default:
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        static void DoCalculationsForType(Type t)
        {
            Console.WriteLine(t.Name);
            Console.WriteLine("Select a calculation option otherwise it will cancel:");
            var constructs = ConstructorExtension.GetConstructs(t).ToArray();
            int optionNumber = 1;
            foreach (var construct in constructs)
            {
                Console.Write(optionNumber + ". ");
                Console.WriteLine(construct.ToString());
                optionNumber++;
            }
            string selected = Console.ReadLine();
            try
            {
                int selectedNum = int.Parse(selected);
                if ((selectedNum - 1) < constructs.Length && selectedNum > 0)
                {
                    var construct = constructs[selectedNum - 1];
                    object[] buildParams = new object[construct.TotalParamerters];
                    for (int i = 0; i < buildParams.Length; i++)
                    {
                        Console.WriteLine("Enter parameter " + (i + 1) + ":");
                        Console.WriteLine("It's type is " + construct.Children[i].ArgType.Name);
                        if (construct.Children[i].ArgType == typeof(double))
                        {
                            buildParams[i] = double.Parse(Console.ReadLine());
                        }
                        else if (construct.Children[i].ArgType.IsEnum)
                        {
                            buildParams[i] = Enum.ToObject(construct.Children[i].ArgType, int.Parse(Console.ReadLine()));
                        }
                    }
                    var obj = construct.Build(buildParams);
                    Console.WriteLine("Calculated: " + obj);
                }
            }
            catch
            {

            }
        }

        static void PrintSpecificGravities()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("Specific Gravities");
            Console.WriteLine("Pick a number:");
            Console.WriteLine("1. Mass Specific Gravity");
            Console.WriteLine("2. Specific Gravity Of Solids");
            Console.WriteLine("3. Specific Gravity Of Water");
            Console.WriteLine("4. Specific Gravity Of Common Substances");
            Console.WriteLine("5 or [else]. End Program.");
            string selection = Console.ReadLine();
            try
            {
                int numSelect = int.Parse(selection);
                switch (numSelect)
                {
                    case 1:
                        DoCalculationsForType(typeof(MassSpecificGravity));
                        break;
                    case 2:
                        DoCalculationsForType(typeof(SpecificGravityOfSolids));
                        break;
                    case 3:
                        DoCalculationsForType(typeof(SpecificGravityOfWater));
                        break;
                    case 4:
                        SpecificGravityQuartz sgq = new SpecificGravityQuartz();
                        SpecificGravityNominalSoilMinimum min = new SpecificGravityNominalSoilMinimum();
                        SpecificGravityNominalSoilMaximum max = new SpecificGravityNominalSoilMaximum();
                        Console.WriteLine("The nominal minimum specific gravity of soil is " + min);
                        Console.WriteLine("The nominal maximum specific gravity of soil is " + max);
                        Console.WriteLine("The nominal specific gravity of quartz is " + sgq);
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void PrintUnitWeights()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("Unit Weights");
            Console.WriteLine("Pick a number:");
            Console.WriteLine("1. Density");
            Console.WriteLine("2. Total Unit Weight");
            Console.WriteLine("3. Unit Weight of Solids");
            Console.WriteLine("4. Unit Weight of Water");
            Console.WriteLine("5. Unit Weight of Common Substances");
            Console.WriteLine("6 or [else]. End Program.");
            string selection = Console.ReadLine();
            try
            {
                int numSelect = int.Parse(selection);
                switch (numSelect)
                {
                    case 1:
                        DoCalculationsForType(typeof(Density));
                        break;
                    case 2:
                        DoCalculationsForType(typeof(TotalUnitWeight));
                        break;
                    case 3:
                        DoCalculationsForType(typeof(UnitWeightOfSolids));
                        break;
                    case 4:
                        DoCalculationsForType(typeof(UnitWeightOfWater));
                        break;
                    case 5:
                        UnitWeightOfWaterAt4DegreesC four = new UnitWeightOfWaterAt4DegreesC();
                        Console.WriteLine("The nominal unit weight of water at 4 degrees C is " + four);
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void PrintVolumes()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("Volumes");
            Console.WriteLine("Pick a number:");
            Console.WriteLine("1. Degree Of Saturation");
            Console.WriteLine("2. Gas Volume");
            Console.WriteLine("3. Porosity");
            Console.WriteLine("4. Total Volume");
            Console.WriteLine("5. Void Ratio");
            Console.WriteLine("6. Volume of Solid Matter");
            Console.WriteLine("7. Volume of Voids");
            Console.WriteLine("8. Water Volume");
            Console.WriteLine("9 or [else]. End Program.");
            string selection = Console.ReadLine();
            try
            {
                int numSelect = int.Parse(selection);
                switch (numSelect)
                {
                    case 1:
                        DoCalculationsForType(typeof(DegreeOfSaturation));
                        break;
                    case 2:
                        DoCalculationsForType(typeof(GasVolume));
                        break;
                    case 3:
                        DoCalculationsForType(typeof(Porosity));
                        break;
                    case 4:
                        DoCalculationsForType(typeof(TotalVolume));
                        break;
                    case 5:
                        DoCalculationsForType(typeof(VoidRatio));
                        break;
                    case 6:
                        DoCalculationsForType(typeof(VolumeOfSolidMatter));
                        break;
                    case 7:
                        DoCalculationsForType(typeof(VolumeOfVoids));
                        break;
                    case 8:
                        DoCalculationsForType(typeof(WaterVolume));
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void PrintWeights()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.WriteLine("Weights");
            Console.WriteLine("Pick a number:");
            Console.WriteLine("1. Total Weight");
            Console.WriteLine("2. Water Content");
            Console.WriteLine("3. Weight Of Solid Matter");
            Console.WriteLine("4. Weight Of Water");
            Console.WriteLine("5. or [else]. End Program.");
            string selection = Console.ReadLine();
            try
            {
                int numSelect = int.Parse(selection);
                switch (numSelect)
                {
                    case 1:
                        DoCalculationsForType(typeof(TotalWeight));
                        break;
                    case 2:
                        DoCalculationsForType(typeof(WaterContent));
                        break;
                    case 3:
                        DoCalculationsForType(typeof(WeightOfSolidMatter));
                        break;
                    case 4:
                        DoCalculationsForType(typeof(WeightOfWater));
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            while (PrintMainMenu()) ;
            Console.ResetColor();
            Console.Clear();
        }
    }
}
