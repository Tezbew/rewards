using System;
using Rewards.UI.Panel;

namespace Rewards.UI.Management.Layer
{
    public interface ILayer : IDisposable
    {
        void Add(IPanel panel);
    }
}