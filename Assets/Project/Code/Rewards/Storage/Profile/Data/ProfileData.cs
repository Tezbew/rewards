using System.Collections.Generic;
using Newtonsoft.Json;
using Rewards.Item;
using Rewards.Resource;

namespace Rewards.Storage.Profile.Data
{
    [JsonObject]
    public class ProfileData
    {
        public Dictionary<ResourceType, int> Resources;
        public List<ItemType> Items;
    }
}