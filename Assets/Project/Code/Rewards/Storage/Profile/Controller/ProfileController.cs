using System;
using System.Collections.Generic;
using System.Linq;
using Rewards.Item;
using Rewards.Resource;
using Rewards.Storage.Profile.Data;
using Rewards.Storage.SaveStrategy;

namespace Rewards.Storage.Profile.Controller
{
    public class ProfileController : IProfileController
    {
        private readonly ISaveStrategy _saveStrategy;
        private ProfileData _data;

        public ProfileController(ISaveStrategy saveStrategy)
        {
            _saveStrategy = saveStrategy;
        }

        public void Initialize()
        {
            if (_saveStrategy.TryLoad<ProfileData>(DataLoaded))
            {
                return;
            }

            var instance = new ProfileData();
            DataLoaded(instance);
        }

        public IReadOnlyList<ResourceType> GetResources()
        {
            return Resources.Keys.ToArray();
        }

        public int GetQuantity(ResourceType resource)
        {
            TryAdd(resource);

            return Resources[resource];
        }

        public void ModifyResource(ResourceType resource, int quantity)
        {
            TryAdd(resource);
            Resources[resource] += quantity;
            Save();
        }

        public bool ContainsItem(ItemType item)
        {
            return Items.Contains(item);
        }

        public void AddItem(ItemType item)
        {
            if (ContainsItem(item))
            {
                throw new InvalidOperationException($"Can't add duplicate item {item.ToString()}");
            }

            Items.Add(item);
            Save();
        }

        private Dictionary<ResourceType, int> Resources => _data.Resources;

        private List<ItemType> Items => _data.Items;

        private bool TryAdd(ResourceType resource)
        {
            return Resources.TryAdd(resource, value: 0);
        }

        private void Save()
        {
            _saveStrategy.Save(_data, SaveFinished);
        }

        private void DataLoaded(ProfileData data)
        {
            _data = data;
        }

        private void SaveFinished()
        {
        }
    }
}