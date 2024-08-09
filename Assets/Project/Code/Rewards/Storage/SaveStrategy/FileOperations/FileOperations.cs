using System;
using System.IO;

namespace Rewards.Storage.SaveStrategy.FileOperations
{
    public class FileOperations : IFileOperations
    {
        public void Read(string path, Action<string> finished)
        {
            ReadAsync(path, finished);
        }

        public void Write(string value, string path, Action finished)
        {
            WriteAsync(value, path, finished);
        }

        private static async void WriteAsync(string value, string path, Action finished)
        {
            await using var writer = new StreamWriter(path, append: false);
            await writer.WriteAsync(value);
            writer.Close();
            finished?.Invoke();
        }

        private static async void ReadAsync(string path, Action<string> finished)
        {
            using var reader = new StreamReader(path);
            var result = await reader.ReadToEndAsync();
            reader.Close();
            finished?.Invoke(result);
        }
    }
}