using System;
using System.Collections.Generic;
using Rewards.UI.Management.Layer;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Rewards.Unity.UI.Management.Opener.Layer.Manager
{
    public class LayerManager : ILayerManager
    {
        private readonly Dictionary<LayerType, ILayer> _layers;
        private readonly Dictionary<LayerType, Transform> _roots;
        private GameObject _parent;

        public ILayer Get(LayerType layerType)
        {
            if (_layers.ContainsKey(layerType) == false)
            {
                var layerRoot = CreateLayerRoot(layerType);
                _roots[layerType] = layerRoot.transform;
                _layers[layerType] = CreateLayer(layerType);
            }

            return _layers[layerType];
        }

        public Transform GetRoot(LayerType layerType)
        {
            return _roots[layerType];
        }

        public void Dispose()
        {
            foreach (var currentPair in _layers)
            {
                var layer = currentPair.Value;
                layer.Dispose();
            }

            _layers.Clear();
            _roots.Clear();
            Object.Destroy(_parent);
        }

        private Transform CreateLayerRoot(LayerType layerType)
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

            return layerGO.transform;
        }

        private ILayer CreateLayer(LayerType layerType)
        {
            ILayer layer = layerType switch
            {
                LayerType.Screen => new ScreenLayer(),
                LayerType.Stack => new StackLayer(),
                _ => throw new ArgumentOutOfRangeException(nameof(layerType), layerType, message: null)
            };

            return layer;
        }
    }
}