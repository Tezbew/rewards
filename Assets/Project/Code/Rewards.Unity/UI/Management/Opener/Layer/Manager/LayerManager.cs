using System;
using System.Collections.Generic;
using Rewards.UI.Management.Layer;
using Rewards.UI.Management.Layer.Manager;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Rewards.Unity.UI.Management.Opener.Layer.Manager
{
    public class LayerManager : ILayerManager
    {
        private readonly Dictionary<LayerType, ILayer> _layers;
        private GameObject _parent;

        public ILayer Get(LayerType layerType)
        {
            if (_layers.ContainsKey(layerType) == false)
            {
                var layerRoot = CreateLayerRoot(layerType);
                _layers[layerType] = CreateLayer(layerType, layerRoot);
            }

            return _layers[layerType];
        }

        public void Dispose()
        {
            foreach (var currentPair in _layers)
            {
                var layer = currentPair.Value;
                layer.Dispose();
            }

            _layers.Clear();
            Object.Destroy(_parent);
        }

        private GameObject CreateLayerRoot(LayerType layerType)
        {
            if (_parent == null)
            {
                _parent = new GameObject(name: "UI");
                Object.DontDestroyOnLoad(_parent);
            }

            var layerGO = new GameObject(layerType.ToString())
            {
                transform =
                {
                    parent = _parent.transform
                }
            };

            return layerGO;
        }

        private ILayer CreateLayer(LayerType layerType, GameObject root)
        {
            var layerTransform = root.transform;
            ILayer layer = layerType switch
            {
                LayerType.Screen => new ScreenLayer(layerTransform),
                LayerType.Stack => new StackLayer(layerTransform),
                _ => throw new ArgumentOutOfRangeException(nameof(layerType), layerType, message: null)
            };

            return layer;
        }
    }
}