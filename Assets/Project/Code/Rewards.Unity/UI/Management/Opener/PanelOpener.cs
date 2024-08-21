using System.Collections.Generic;
using Rewards.UI.Management.Layer;
using Rewards.UI.Management.Opener;
using Rewards.Unity.UI.Management.Config;
using IPanel = Rewards.UI.Panel.IPanel;
using Object = UnityEngine.Object;

namespace Rewards.Unity.UI.Management.Opener
{
    public class PanelOpener : IPanelOpener
    {
        private readonly Dictionary<LayerType, ILayer> _layers;
        private readonly PanelConfigCollectionSO _configs;

        public PanelOpener(PanelConfigCollectionSO configs)
        {
            _configs = configs;
        }

        public TPanel Open<TPanel>() where TPanel : class, IPanel
        {
            var template = _configs.FindTemplate<TPanel>();
            var instance = Object.Instantiate(template) as TPanel;
            var layerType = _configs.FindLayer<TPanel>();
            _layers[layerType].Add(instance);

            return instance;
        }
    }
}