using Newtonsoft.Json;
using Rewards.Resource;

namespace Rewards.Storage.Config.Data
{
    [JsonObject]
    public class ResourceConfig
    {
        public ResourceType Type;
        public int MaxValue;
    }
}