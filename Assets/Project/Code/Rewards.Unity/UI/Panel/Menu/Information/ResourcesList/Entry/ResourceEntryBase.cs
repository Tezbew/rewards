using Rewards.Resource;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ResourcesList.Entry
{
    public abstract class ResourceEntryBase : MonoBehaviour
    {
        public abstract ResourceType Resource { get; protected set; }
        public abstract void Initialize(ResourceType resource, int count);
        public abstract void SetCount(int count);
    }
}