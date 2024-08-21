using System;
using System.Collections.Generic;
using Rewards.UI.Management.Opener;
using Rewards.UI.Panel;
using Rewards.Unity.UI.Panel;
using Object = UnityEngine.Object;

namespace Rewards.Unity.UI.Management.Opener
{
    public class PanelOpener : IPanelOpener
    {
        private readonly Dictionary<Type, PanelBase> _templates;

        public PanelOpener(Dictionary<Type, PanelBase> templates)
        {
            _templates = templates;
        }

        public TPanel Open<TPanel>() where TPanel : class, IPanel
        {
            var panelType = typeof(TPanel);
            var template = _templates[panelType];
            var instance = Object.Instantiate(template) as TPanel;

            return instance;
        }
    }
}