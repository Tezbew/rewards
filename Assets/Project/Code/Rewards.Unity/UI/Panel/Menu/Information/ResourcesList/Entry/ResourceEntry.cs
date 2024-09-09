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

        private ResourceType _resource;

        public override ResourceType Resource
        {
            get => _resource;
            protected set
            {
                _resource = value;
                _nameField.text = _resource.ToString();
            }
        }

        public override void Initialize(ResourceType resource, int count)
        {
            Resource = resource;
            SetCount(count);
        }

        public override void SetCount(int count)
        {
            _countField.text = count.ToString();
        }
    }
}