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
        private readonly Dictionary<LayerType, LayerBase> _layers;
        private GameObject _parent;

        public ILayer Get(LayerType layerType)
        {
            if (_layers.ContainsKey(layerType) == false)
            {
                _layers[layerType] = CreateLayer(layerType);
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

        private LayerBase CreateLayer(LayerType layerType)
        {
            if (_parent == null)
            {
                _parent = new GameObject("UI");
                Object.DontDestroyOnLoad(_parent);
            }
            
            var layerGO = new GameObject(layerType.ToString())
            {
                transform =
                {
                    parent = _parent.transform
                }
            };
            LayerBase layer = layerType switch
            {
                LayerType.Screen => layerGO.AddComponent<ScreenLayer>(),
                LayerType.Stack => layerGO.AddComponent<StackLayer>(),
                _ => throw new ArgumentOutOfRangeException(nameof(layerType), layerType, message: null)
            };

            return layer;
        }
    }
}