using Rewards.LootBox.Config;
using Rewards.Unity.CreateMenu;
using UnityEngine;

namespace Rewards.Unity.LootBox.Config.SO
{
    [CreateAssetMenu(menuName = CreateMenuItems.ROOT + "/" + TYPE_NAME, fileName = TYPE_NAME)]
    public partial class LootBoxConfigSO : ScriptableObject
    {
        [SerializeField]
        private LootBoxConfig _config;

        private const string TYPE_NAME = nameof(LootBoxConfigSO);

        public LootBoxConfig Config => _config;
    }
}