using System.Reflection;

namespace Finch.Tests.Shared;

public static class Solution
{
    private const string SolutionFileName = "Finch.sln";

    static Solution()
    {
        var binConfigurationDirectoryPath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        SolutionRootPath = GetSolutionRootPath(binConfigurationDirectoryPath, SolutionFileName);
    }

    public static string SolutionRootPath { get; }

    private static string GetSolutionRootPath(string binConfigurationDirectoryPath, string solutionFileName)
    {
        var solutionDirectoryPath = Directory.GetParent(binConfigurationDirectoryPath)!.FullName;
        while (!File.Exists(Path.Combine(solutionDirectoryPath, solutionFileName)))
            solutionDirectoryPath = Directory.GetParent(solutionDirectoryPath)!.FullName;

        return solutionDirectoryPath;
    }
}