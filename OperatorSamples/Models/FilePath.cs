namespace OperatorSamples.Models;


    public class FilePath(string path)
    {
        public static implicit operator string(FilePath self) => self?.ToString();
        public static implicit operator FilePath(string value) => new(value);
        public override string ToString() => path;
    }