using Rewards.Resource;
using TMPro;
using UnityEngine;

namespace Rewards.Unity.UI.Panel.Menu.Information.ResourcesList.Entry
{
    public class ResourceEntry : ResourceEntryBase
    {
        [SerializeField]
        private TMP_Text _nameField;

        [SerializeField]
        private TMP_Text _countField;

        public override void Initialize(ResourceType resource, int count)
        {
            _nameField.text = resource.ToString();
            _countField.text = count.ToString();
        }
    }
}