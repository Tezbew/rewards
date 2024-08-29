using System;
using System.Collections.Generic;
using Rewards.LootBox.Version;
using Rewards.Storage.Profile.Controller;
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

        public override event Action<LootBoxVersion> Selected;

        public override void Initialize(IReadOnlyList<LootBoxVersion> lootBoxes, IProfileController profile)
        {
            LogInfo();
            _information.Initialize(lootBoxes, profile);
            _information.Selected += BoxSelectedEventHandler;

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
            _information.Selected -= BoxSelectedEventHandler;
            _information.Dispose();
            _clearSavesButton.onClick.RemoveListener(ClearSaves);
        }

        private void BoxSelectedEventHandler(LootBoxVersion box)
        {
            Selected?.Invoke(box);
        }

        private void ClearSaves()
        {
            LogInfo();
        }
    }
}