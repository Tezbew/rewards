using System;
using System.Collections.Generic;
using Rewards.Item;
using Rewards.Resource;

namespace Rewards.Storage.Profile.Controller
{
    public interface IProfileController
    {
        void Initialize(Action callback);
        IReadOnlyList<ResourceType> GetResources();
        int GetQuantity(ResourceType resource);
        void ModifyResource(ResourceType resource, int quantity);
        bool ContainsItem(ItemType item);
        void AddItem(ItemType item);
    }
}