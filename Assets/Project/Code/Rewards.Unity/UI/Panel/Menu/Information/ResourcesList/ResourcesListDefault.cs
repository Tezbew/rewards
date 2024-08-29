using System;
using System.Collections.Generic;
using Rewards.Resource;
using Rewards.Storage.Profile.Controller;
using Rewards.Unity.UI.Panel.Menu.Information.ResourcesList.Entry;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ResourcesList
{
    public class ResourcesListDefault : ResourcesListBase
    {
        [SerializeField]
        private ResourceEntryBase _template;

        private readonly List<ResourceEntryBase> _entries = new();

        public override void Initialize(IProfileController profile)
        {
            CreateEntries(profile);
        }

        public override void Show()
        {
            SetActive(isActive: true);
        }

        public override void Hide()
        {
            SetActive(isActive: false);
        }

        public override void Dispose()
        {
            for (var i = _entries.Count - 1; i >= 0; i--)
            {
                var entry = _entries[i];
                Destroy(entry.gameObject);
                _entries.RemoveAt(i);
            }
        }

        private void CreateEntries(IProfileController profile)
        {
            var allResources = (ResourceType[])Enum.GetValues(typeof(ResourceType));
            foreach (var currentResource in allResources)
            {
                var count = profile.GetQuantity(currentResource);
                var instance = Instantiate(_template, transform);
                instance.Initialize(currentResource, count);
                _entries.Add(instance);
            }
        }

        private void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}