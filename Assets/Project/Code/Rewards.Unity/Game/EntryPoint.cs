using Rewards.Coroutine;
using Rewards.LootBox.Model;
using Rewards.Storage.SaveStrategy;
using Rewards.Storage.SaveStrategy.FileOperations;
using Rewards.Unity.Coroutine.Manager;
using Rewards.Unity.LootBox.Config.SO;
using UnityEngine;

namespace Rewards.Unity.Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private LootBoxCollectionConfigSO _lootBoxCollectionConfigSO;

        private string _saveDataPath;
        private IFileOperations _fileOperations;
        private ISaveStrategy _saveStrategy;
        private ICoroutineManager _coroutineManager;

        private void Awake()
        {
            _saveDataPath = Application.persistentDataPath;
            _fileOperations = new FileOperations();
            _saveStrategy = new JsonFileStrategy(_fileOperations, _saveDataPath);

            var coroutineManagerGO = new GameObject(nameof(ICoroutineManager));
            DontDestroyOnLoad(coroutineManagerGO);
            _coroutineManager = coroutineManagerGO.AddComponent<CoroutineManager>();

            foreach (var currentConfig in _lootBoxCollectionConfigSO.Boxes)
            {
                var model = new LootBoxModel(currentConfig);
                var viewTemplate = _lootBoxCollectionConfigSO.FindView(currentConfig.Version);
                var view = Instantiate(viewTemplate);
                view.Initialize(model);
            }
        }
    }
}