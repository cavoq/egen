var target = Argument("target", "Default");
var version = "0.0.1";
var project = "egen";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    Information("Building the application...");

    StartProcess("docker", new ProcessSettings 
    {
        Arguments = $"build -t {project}:{version} ."
    });
});

Task("Run")
    .IsDependentOn("Build")
    .Does(() =>
{
    Information("Running the application...");

    StartProcess("docker", new ProcessSettings 
    {
        Arguments = $"run -it {project}:{version} /bin/bash",
    });
});

Task("Clean")
    .Does(() =>
{
    Information("Cleaning build artifacts...");
    CleanDirectory("./bin");
    CleanDirectory("./obj");
    CleanDirectory("./out");
});

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Run");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
