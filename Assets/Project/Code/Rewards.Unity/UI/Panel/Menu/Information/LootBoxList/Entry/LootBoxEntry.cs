using System;
using Rewards.LootBox.Version;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewards.Unity.UI.Panel.Menu.Information.LootBoxList.Entry
{
    [RequireComponent(typeof(Button))]
    public class LootBoxEntry : LootBoxEntryBase
    {
        [SerializeField]
        private TMP_Text _text;

        private LootBoxVersion _box;
        private Button _button;

        public override event Action<LootBoxVersion> Selected;

        public override void Initialize(LootBoxVersion box)
        {
            _text.text = box.ToString();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ButtonClickedEventHandler);
        }

        public override void Dispose()
        {
            _button.onClick.RemoveListener(ButtonClickedEventHandler);
        }

        private void ButtonClickedEventHandler()
        {
            Selected?.Invoke(_box);
        }
    }
}