using Microsoft.Extensions.FileSystemGlobbing;
using OperatorSamples.Models;

namespace OperatorSamples.Classes;
internal class GlobbingOperations
{
    public delegate void OnTraverseFileMatch(FileMatchItem sender);
    public static event OnTraverseFileMatch TraverseFileMatch;

    public delegate void OnTraverseSolutionMatch(FileMatchItem sender);
    public static event OnTraverseSolutionMatch TraverseSolutionMatch;

    public delegate void OnTraverseSolutionDone(int count);
    public static event OnTraverseSolutionDone TraverseSolutionDone;

    public static Task GetProjectFilesAsync(string folder)
    {

        Matcher matcher = new();
        matcher.AddIncludePatterns(["**/*.csproj"]);

        return Task.Run(() =>
        {
            foreach (var file in matcher.GetResultsInFullPath(folder))
            {
                TraverseFileMatch?.Invoke(new FileMatchItem(file));
            }
        });
    }

    public static async Task GetSolutionFilesAsync(string folder)
    {
        int count = 0;
        
        Matcher matcher = new();
        matcher.AddIncludePatterns(["**/*.sln"]);

        await Task.Run(() =>
        {
            foreach (var file in matcher.GetResultsInFullPath(folder))
            {
                TraverseSolutionMatch?.Invoke(new FileMatchItem(file));
                count++;
            }
        });

        TraverseSolutionDone?.Invoke(count);
    }

}