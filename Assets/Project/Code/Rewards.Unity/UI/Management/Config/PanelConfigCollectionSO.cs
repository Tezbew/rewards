using System.Collections;
using System.Collections.Generic;
using Rewards.Unity.CreateMenu;
using UnityEngine;

namespace Rewards.Unity.UI.Management.Config
{
    [CreateAssetMenu(menuName = CreateMenuItems.ROOT + "/" + TYPE_NAME, fileName = TYPE_NAME)]
    public class PanelConfigCollectionSO : ScriptableObject, IPanelConfigCollection
    {
        [SerializeField]
        private PanelConfig[] _configs;

        private const string TYPE_NAME = nameof(PanelConfigCollectionSO);

        public IEnumerator<PanelConfig> GetEnumerator()
        {
            return (IEnumerator<PanelConfig>)_configs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}