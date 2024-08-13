using Rewards.LootBox.Config;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Rewards.Unity.Editor.LootBox.Config
{
    [CustomPropertyDrawer(typeof(RewardResourceConfig))]
    public class RewardResourceConfigDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var root = new VisualElement();

            var resourceProperty = property.FindPropertyRelative(nameof(RewardResourceConfig.Resource));
            var probabilityProperty = property.FindPropertyRelative(nameof(RewardResourceConfig.Probability));
            var countProperty = property.FindPropertyRelative(nameof(RewardResourceConfig.Count));


            var firstRow = new VisualElement
            {
                style =
                {
                    flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row)
                }
            };

            var resourceField = new PropertyField(resourceProperty, string.Empty)
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

            firstRow.Add(resourceField);
            firstRow.Add(probabilityField);

            var countField = new PropertyField(countProperty);

            root.Add(firstRow);
            root.Add(countField);

            return root;
        }
    }
}