using Rewards.UI.Management.Layer.Manager;
using Rewards.UI.Management.Opener;
using Rewards.Unity.UI.Management.Config;
using IPanel = Rewards.UI.Panel.IPanel;
using Object = UnityEngine.Object;

namespace Rewards.Unity.UI.Management.Opener
{
    public class PanelOpener : IPanelOpener
    {
        private readonly ILayerManager _layerManager;
        private readonly UIConfig _configs;

        public PanelOpener(ILayerManager layerManager, UIConfig configs)
        {
            _layerManager = layerManager;
            _configs = configs;
        }

        public TPanel Open<TPanel>() where TPanel : class, IPanel
        {
            var template = _configs.FindTemplate<TPanel>();
            var instance = Object.Instantiate(template) as TPanel;
            var layerType = _configs.FindLayer<TPanel>();
            var layer = _layerManager.Get(layerType);
            layer.Add(instance);

            return instance;
        }
    }
}