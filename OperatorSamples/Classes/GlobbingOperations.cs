using Microsoft.Extensions.FileSystemGlobbing;
using OperatorSamples.Models;

namespace OperatorSamples.Classes;
internal class GlobbingOperations
{
    public delegate void OnTraverseFileMatch(FileMatchItem sender);
    public static event OnTraverseFileMatch? TraverseFileMatch;

    public static Task GetProjectFilesAsync(string folder)
    {

        Matcher matcher = new();
        matcher.AddIncludePatterns(new[] { "**/*.csproj" });

        return Task.Run(() =>
        {
            foreach (var file in matcher.GetResultsInFullPath(folder))
            {
                TraverseFileMatch?.Invoke(new FileMatchItem(file));
            }
        });
    }

}