using Rewards.LootBox.Model;

namespace Rewards.Unity.LootBox.View
{
    public class LootBoxView : LootBoxViewBase
    {
        private ILootBoxModel _model;

        public override void Initialize(ILootBoxModel model)
        {
            _model = model;
        }
    }
}