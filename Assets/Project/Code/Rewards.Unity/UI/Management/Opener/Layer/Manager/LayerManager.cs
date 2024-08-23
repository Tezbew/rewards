using System;
using System.Collections.Generic;
using Rewards.UI.Management.Layer;
using Rewards.Unity.UI.Root;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Rewards.Unity.UI.Management.Opener.Layer.Manager
{
    public class LayerManager : ILayerManager
    {
        private readonly Dictionary<LayerType, ILayer> _layers;
        private readonly Dictionary<LayerType, Transform> _roots;
        private readonly RootBase _rootTemplate;
        private RootBase _root;

        public LayerManager(RootBase rootTemplate)
        {
            _rootTemplate = rootTemplate;
            _layers = new Dictionary<LayerType, ILayer>();
            _roots = new Dictionary<LayerType, Transform>();
        }
        
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
            Object.Destroy(_root);
        }

        private Transform CreateLayerRoot(LayerType layerType)
        {
            if (_root == null)
            {
                _root = Object.Instantiate(_rootTemplate);
                _root.name = "UI";
                Object.DontDestroyOnLoad(_root.gameObject);
            }

            var layerGO = new GameObject(layerType.ToString())
            {
                transform =
                {
                    parent = _root.transform
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