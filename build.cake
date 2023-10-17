var target = Argument("target", "Default");
var version = "0.0.1";
var project = "egen";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("docker-build")
    .Does(() =>
{
    Information("Building the docker-image...");

    StartProcess("docker", new ProcessSettings
    {
        Arguments = $"build -t {project}:{version} ."
    });
});

Task("docker-shell")
    .IsDependentOn("docker-build")
    .Does(() =>
{
    Information("Shell into docker-container...");

    StartProcess("docker", new ProcessSettings
    {
        Arguments = $"run -it {project}:{version} /bin/bash",
    });
});

Task("build")
    .IsDependentOn("clean")
    .Does(() =>
{
    Information("Building the application...");

    StartProcess("dotnet", new ProcessSettings
    {
        Arguments = $"build -c Release"
    });
});

Task("test")
    .IsDependentOn("build")
    .Does(() =>
{
    Information("Testing the app inside container environment...");

    StartProcess("dotnet", new ProcessSettings
    {
        Arguments = $"test -c Release"
    });
});

Task("run")
    .IsDependentOn("build")
    .Does(() =>
{
    StartProcess("dotnet", new ProcessSettings
    {
        Arguments = $"run -c Release"
    });
});

Task("clean")
    .Does(() =>
{
    Information("Cleaning build artifacts...");
    CleanDirectory("./bin");
    CleanDirectory("./obj");
    CleanDirectory("./out");
});

Task("default")
    .IsDependentOn("build")
    .IsDependentOn("run");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
