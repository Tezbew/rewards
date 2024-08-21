using System;
using Rewards.Unity.UI.Panel;

namespace Rewards.Unity.UI.Management.Config
{
    [Serializable]
    public class PanelConfig
    {
        public string Name;
        public string LayerType;
        public PanelBase Template;
    }
}