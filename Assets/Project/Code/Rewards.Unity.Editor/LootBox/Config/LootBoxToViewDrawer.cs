using Rewards.Unity.LootBox.Config;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Rewards.Unity.Editor.LootBox.Config
{
    [CustomPropertyDrawer(typeof(LootBoxToView))]
    public class LootBoxToViewDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var itemsProperty = property.FindPropertyRelative(nameof(LootBoxToView.Version));
            var resourcesProperty = property.FindPropertyRelative(nameof(LootBoxToView.View));

            var root = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Row
                }
            };

            var itemsField = new PropertyField(itemsProperty, string.Empty)
            {
                style = { width = 150 }
            };
            var resourcesField = new PropertyField(resourcesProperty, string.Empty)
            {
                style =
                {
                    flexGrow = 1
                }
            };

            root.Add(itemsField);
            root.Add(resourcesField);

            return root;
        }
    }
}