Task("SetVersion")
    .Does(() =>
{
    var version = Argument("version", "1.0.0");
    Information($"Setting version to {version}");
    DotNetCoreTool("dotnet", $"maven versions:set -DnewVersion={version}");
});

Task("RunTests")
    .Does(() =>
{
    Information("Running tests");
    DotNetCoreTool("dotnet", "maven test");
});

Task("Default")
    .IsDependentOn("SetVersion")
    .IsDependentOn("RunTests");

RunTarget("Default");