using System;

namespace Rewards.Storage.SaveStrategy.FileOperations
{
    public interface IFileOperations
    {
        void Read(string path, Action<string> finished);
        void Write(string value, string path, Action finished);
    }
}