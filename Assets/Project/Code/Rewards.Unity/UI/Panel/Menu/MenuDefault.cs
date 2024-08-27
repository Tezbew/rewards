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
            
        }

        public override void Initialize()
        {
            _information.Initialize();
        }
    }
}