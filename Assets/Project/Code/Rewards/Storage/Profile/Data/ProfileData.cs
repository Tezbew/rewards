using System;
using System.Collections.Generic;
using Rewards.Item;
using Rewards.Resource;

namespace Rewards.Storage.Profile.Data
{
    [Serializable]
    public class ProfileData
    {
        public Dictionary<ResourceType, int> Resources = new();
        public List<ItemType> Items = new();
    }
}