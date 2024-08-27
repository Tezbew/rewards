using Rewards.Unity.UI.Panel.Menu.Information;
using UnityEngine;
using UnityEngine.UI;

namespace Rewards.Unity.UI.Panel.Menu
{
    public class MenuDefault : MenuBase
    {
        [SerializeField]
        private Button _clearSavesButton;

        [SerializeField]
        private InformationBase _information;

        public override void Initialize()
        {
            LogInfo();
            _information.Initialize();

            _clearSavesButton.onClick.AddListener(ClearSaves);
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        protected override void OnDispose()
        {
            _information.Dispose();
            _clearSavesButton.onClick.RemoveListener(ClearSaves);
        }

        private void ClearSaves()
        {
            LogInfo();
        }
    }
}