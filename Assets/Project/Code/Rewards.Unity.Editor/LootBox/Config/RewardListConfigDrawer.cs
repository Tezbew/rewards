using Rewards.LootBox.Config;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Rewards.Unity.Editor.LootBox.Config
{
    [CustomPropertyDrawer(typeof(RewardListConfig))]
    public class RewardListConfigDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var root = new VisualElement();

            var itemsProperty = property.FindPropertyRelative(nameof(RewardListConfig.Items));
            var resourcesProperty = property.FindPropertyRelative(nameof(RewardListConfig.Resources));

            var itemsField = new PropertyField(itemsProperty);
            var resourcesField = new PropertyField(resourcesProperty);

            root.Add(itemsField);
            root.Add(resourcesField);

            return root;
        }
    }
}