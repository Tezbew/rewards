using System;
using Rewards.Item;
using Rewards.Resource;

namespace Rewards.Storage.Profile.Controller
{
    public interface IProfileController
    {
        void Initialize(Action callback);
        int GetQuantity(ResourceType resource);
        void ModifyResource(ResourceType resource, int quantity, Action callback = null);
        bool ContainsItem(ItemType item);
        void AddItem(ItemType item, Action callback = null);
        void Clear(Action callback = null);
    }
}