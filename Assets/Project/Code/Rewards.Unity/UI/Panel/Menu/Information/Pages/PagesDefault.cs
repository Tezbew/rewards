using System;
using System.Collections.Generic;
using Rewards.Exceptions;
using UnityEngine.UI;

namespace Rewards.Unity.UI.Panel.Menu.Information.Pages
{
    public class PagesDefault : PagesBase
    {
        private readonly List<Toggle> _toggles = new();

        public override event Action<int> ToggleActivated;

        public override void Initialize()
        {
            GetComponentsInChildren(_toggles);
            if (_toggles.Count == 0)
            {
                throw new ElementNotFountException(message: "Can't find any toggle");
            }

            for (var i = 0; i < _toggles.Count; i++)
            {
                var index = i;
                var currentToggle = _toggles[i];
                currentToggle.onValueChanged.AddListener(value => ValueChangedEventHandler(index, value));
                ValueChangedEventHandler(i, currentToggle.isOn);
            }
        }

        public override void Dispose()
        {
            foreach (var t in _toggles)
            {
                t.onValueChanged.RemoveAllListeners();
            }
        }

        private void ValueChangedEventHandler(int index, bool value)
        {
            if (value == false)
            {
                return;
            }

            ToggleActivated?.Invoke(index);
        }
    }
}