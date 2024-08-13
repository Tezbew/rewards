using Rewards.LootBox.Config;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Rewards.Unity.Editor.LootBox.Config
{
    [CustomPropertyDrawer(typeof(RewardItemConfig))]
    public class RewardItemConfigDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            var containerStyle = container.style;
            containerStyle.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);

            var itemProperty = property.FindPropertyRelative(nameof(RewardItemConfig.Item));
            var probabilityProperty = property.FindPropertyRelative(nameof(RewardItemConfig.Probability));

            var itemField = new PropertyField(itemProperty, string.Empty)
            {
                style =
                {
                    width = new StyleLength(v: 150)
                }
            };

            var probabilityField = new Slider
            {
                bindingPath = probabilityProperty.propertyPath,
                value = 0,
                lowValue = 0,
                highValue = 100,
                showInputField = true,
                style =
                {
                    flexGrow = new StyleFloat(v: 1),
                    paddingLeft = new StyleLength(v: 5),
                    paddingRight = new StyleLength(v: 5)
                }
            };

            container.Add(itemField);
            container.Add(probabilityField);

            return container;
        }
    }
}