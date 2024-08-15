using Rewards.LootBox.Model;
using UnityEngine;

namespace Rewards.Unity.LootBox.View
{
    public abstract class LootBoxViewBase : MonoBehaviour
    {
        public abstract void Initialize(ILootBoxModel model);
    }
}