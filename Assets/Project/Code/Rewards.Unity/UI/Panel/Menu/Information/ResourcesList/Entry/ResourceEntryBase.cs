using Rewards.Resource;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ResourcesList.Entry
{
    public abstract class ResourceEntryBase : MonoBehaviour
    {
        public abstract void Initialize(ResourceType resource, int count);
    }
}