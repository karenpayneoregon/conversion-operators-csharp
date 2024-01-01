using OperatorSamples.Classes;

namespace OperatorSamples.Models;

public class PathOperations
{
    public void PrintFolderContents(string path)
    {
        GlobbingOperations.TraverseFileMatch += GlobbingOperations_TraverseFileMatch;
        GlobbingOperations.GetProjectFilesAsync(path);
    }

    private void GlobbingOperations_TraverseFileMatch(FileMatchItem sender)
    {
        Console.WriteLine(Path.GetFileNameWithoutExtension(sender.FileName));
    }

    public void PathExists(FilePath path)
    {
        AnsiConsole.MarkupLine(Path.Exists(path)
            ? $"[cyan]{nameof(PathExists)}[/] [yellow]{path}[/] [cyan]exists[/]"
            : $"[cyan]{nameof(PathExists)}[/] [yellow]{path}[/] [cyan]does not exists[/]");
    }
}