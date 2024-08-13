using Rewards.LootBox.Config;
using Rewards.Unity.LootBox.Config.SO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Rewards.Unity.Editor.LootBox.Config.SO
{
    [CustomEditor(typeof(LootBoxConfigSO))]
    public class LootBoxConfigSOEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var container = new VisualElement();

            var configField = serializedObject.FindProperty(LootBoxConfigSO.CONFIG_FIELD_NAME);
            var versionProperty = configField.FindPropertyRelative(nameof(LootBoxConfig.Version));
            var rewardsProperty = configField.FindPropertyRelative(nameof(LootBoxConfig.Rewards));
            
            var versionField = new PropertyField(versionProperty);
            var rewardsField = new PropertyField(rewardsProperty);

            container.Add(versionField);
            container.Add(rewardsField);

            return container;
        }
    }
}