using Rewards.LootBox.Config;
using Rewards.Unity.CreateMenu;
using UnityEngine;

namespace Rewards.Unity.LootBox.Config.SO
{
    [CreateAssetMenu(menuName = CreateMenuItems.ROOT + "/" + TYPE_NAME, fileName = TYPE_NAME)]
    public class LootBoxCollectionConfigSO : ScriptableObject
    {
        [SerializeField]
        private LootBoxConfig[] _boxes;

        private const string TYPE_NAME = nameof(LootBoxCollectionConfigSO);
    }
}