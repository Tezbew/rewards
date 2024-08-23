using System;
using Rewards.UI.Management.Layer;
using UnityEngine;

namespace Rewards.Unity.UI.Management.Opener.Layer.Manager
{
    public interface ILayerManager : IDisposable
    {
        ILayer Get(LayerType layerType);
        Transform GetRoot(LayerType layerType);
    }
}