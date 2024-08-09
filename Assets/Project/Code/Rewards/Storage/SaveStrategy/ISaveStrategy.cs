using System;

namespace Rewards.Storage.SaveStrategy
{
    public interface ISaveStrategy
    {
        void Save<T>(T dataClass, Action finished);
        void Load<T>(Action<T> finished);
    }
}