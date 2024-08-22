using System;

namespace Rewards.UI.Management.Layer.Manager
{
    public interface ILayerManager : IDisposable
    {
        ILayer Get(LayerType layerType);
    }
}