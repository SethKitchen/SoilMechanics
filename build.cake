#tool nuget:?package=MSBuild.SonarQube.Runner.Tool&version=4.6.0
#addin nuget:?package=Cake.Sonar&version=1.1.22
#addin nuget:?package=Cake.Git&version=0.19.0

var target = Argument("target", "Default");
var solutionDir = ".";
var sonarLogin = EnvironmentVariable("SoilMechanics_SonarQube_login");
var branch = EnvironmentVariable("APPVEYOR_REPO_BRANCH") ?? GitBranchCurrent(".").FriendlyName;

if (string.IsNullOrEmpty(sonarLogin))
    throw new Exception("You should set an environment variable 'SoilMechanics_SonarQube_login' with the token generated at the page https://sonarcloud.io/account/security/.");

Task("Build")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = "Release",
    };

    DotNetCoreBuild(solutionDir, settings);
});

Task("Test")
    .Does(() =>
{
    var settings = new DotNetCoreTestSettings
    {
        ArgumentCustomization = args => {
            return args.Append("/p:CollectCoverage=true")
                       .Append("/p:CoverletOutputFormat=opencover");
        }
    };

    DotNetCoreTest(solutionDir, settings);
});

Task("SonarBegin")
    .Does(() => 
{
    SonarBegin(new SonarBeginSettings {
        Key = "SoilMechanics",
        Branch = branch,
        Organization = "sethkitchen",
        Url = "https://sonarcloud.io",
        Exclusions = "SoilMechanics.Benchmarks/*.cs,**/*Test.cs,**/Samples/*.cs,SoilMechanics.Runner.App/MainWindow.cs,SoilMechanics.Runner.App/PropertyEditor.cs,**/*.xml,**/Program.cs,**/AssemblyInfo.cs",
        OpenCoverReportsPath = "**/*.opencover.xml",
        Login = sonarLogin   
     });
});

Task("SonarEnd")
  .Does(() => {
     SonarEnd(new SonarEndSettings{
        Login = sonarLogin
     });
  });

Task("Default")
    .IsDependentOn("SonarBegin")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("SonarEnd")
	.Does(()=> { 
});

RunTarget(target);