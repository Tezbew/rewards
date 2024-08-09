using System;
using System.IO;
using Newtonsoft.Json;
using Rewards.Storage.SaveStrategy.FileOperations;

namespace Rewards.Storage.SaveStrategy
{
    public class JsonFileStrategy : ISaveStrategy
    {
        private readonly IFileOperations _fileOperations;
        private readonly string _path;

        public JsonFileStrategy(IFileOperations fileOperations, string path)
        {
            _fileOperations = fileOperations;
            _path = path;
        }

        public void Save<T>(T dataClass, Action finished)
        {
            var json = JsonConvert.SerializeObject(dataClass);
            var path = GetFullPath<T>();
            _fileOperations.Write(json, path, finished);
        }

        public void Load<T>(Action<T> finished)
        {
            var path = GetFullPath<T>();
            _fileOperations.Read(path, json => JSONLoadFinished(json, finished));
        }

        private static void JSONLoadFinished<T>(string json, Action<T> serializationFinished)
        {
            var dataClass = JsonConvert.DeserializeObject<T>(json);
            serializationFinished?.Invoke(dataClass);
        }

        private static string GetName<T>()
        {
            return typeof(T).Name;
        }

        private string GetFullPath<T>()
        {
            var name = GetName<T>();
            var path = GetFullPath(name);

            return path;
        }

        private string GetFullPath(string name)
        {
            return Path.Combine(_path, $"{name}.json");
        }
    }
}