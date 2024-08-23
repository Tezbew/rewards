using Rewards.UI.Management.Opener;
using Rewards.Unity.UI.Management.Config;
using Rewards.Unity.UI.Management.Opener.Layer.Manager;
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
            var layerType = _configs.FindLayer<TPanel>();
            var layer = _layerManager.Get(layerType);
            var layerRoot = _layerManager.GetRoot(layerType);

            var template = _configs.FindTemplate<TPanel>();
            var instanceBase = Object.Instantiate(template);
            instanceBase.SetParent(layerRoot);

            layer.Add(instanceBase);

            var instance = instanceBase as TPanel;

            return instance;
        }

        public void Dispose()
        {
            _layerManager.Dispose();
        }
    }
}