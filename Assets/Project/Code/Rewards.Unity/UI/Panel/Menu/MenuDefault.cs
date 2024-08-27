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
        
        protected override void OnShow()
        {
            
        }

        protected override void OnHide()
        {
            
        }

        protected override void OnDispose()
        {
            _clearSavesButton.onClick.RemoveListener(ClearSaves);
        }

        public override void Initialize()
        {
            LogInfo();
            _information.Initialize();
            
            _clearSavesButton.onClick.AddListener(ClearSaves);
        }

        private void ClearSaves()
        {
            LogInfo();
        }
    }
}