using System.Collections.Generic;
using Rewards.Unity.UI.Panel.Menu.Information.ResourcesList.Entry;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ResourcesList
{
    public class ResourcesListDefault : ResourcesListBase
    {
        [SerializeField]
        private ResourceEntryBase _template;

        private List<ResourceEntryBase> _entries;

        public override void Initialize()
        {
        }

        public override void Show()
        {
            SetActive(true);
        }

        public override void Hide()
        {
            SetActive(false);
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}