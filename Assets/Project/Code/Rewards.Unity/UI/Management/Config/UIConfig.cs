using System;
using System.Collections.Generic;
using Rewards.UI.Management.Layer;
using Rewards.UI.Panel;
using Rewards.Unity.CreateMenu;
using Rewards.Unity.UI.Panel;
using Rewards.Unity.UI.Root;
using UnityEngine;

namespace Rewards.Unity.UI.Management.Config
{
    [CreateAssetMenu(menuName = CreateMenuItems.ROOT + "/" + TYPE_NAME, fileName = TYPE_NAME)]
    public class UIConfig : ScriptableObject
    {
        [SerializeField]
        private PanelConfig[] _configs;

        [SerializeField]
        private RootBase _root;

        private IDictionary<Type, PanelConfig> _typeToConfig;

        private const string TYPE_NAME = nameof(UIConfig);

        public PanelBase FindTemplate<TPanel>() where TPanel : class, IPanel
        {
            var config = FindConfig<TPanel>();

            return config.Template;
        }

        public LayerType FindLayer<TPanel>() where TPanel : class, IPanel
        {
            var config = FindConfig<TPanel>();

            return config.LayerType;
        }

        public RootBase Root => _root;

        private PanelConfig FindConfig<TPanel>() where TPanel : class, IPanel
        {
            var panelType = typeof(TPanel);
            _typeToConfig ??= CreateDictionary();

            return _typeToConfig[panelType];
        }

        private IDictionary<Type,PanelConfig> CreateDictionary()
        {
            var dictionary = new Dictionary<Type, PanelConfig>();
            
            foreach (var currentConfig in _configs)
            {
                var panelType = currentConfig.Template.GetType();
                var baseType = panelType.BaseType;
                if (baseType == null || baseType.IsAbstract == false || baseType == typeof(PanelBase))
                {
                    throw new InvalidOperationException($"{panelType.Name} is invalid!");
                }
                
                dictionary.Add(baseType, currentConfig);
            }

            return dictionary;
        }
    }
}