using Rewards.Container;
using Rewards.Coroutine;
using Rewards.Storage.SaveStrategy;
using Rewards.Storage.SaveStrategy.FileOperations;
using Rewards.Unity.Coroutine.Manager;
using Rewards.Unity.LootBox.Config.SO;
using Rewards.Unity.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        private ISceneLoader _sceneLoader;
        private IContainer _container;

        private void Awake()
        {
            _container = new ContainerDefault();

            _saveDataPath = Application.persistentDataPath;
            _fileOperations = new FileOperations();
            _container.Register(_fileOperations);

            _saveStrategy = new JsonFileStrategy(_fileOperations, _saveDataPath);
            _container.Register(_saveStrategy);

            var coroutineManagerGO = new GameObject(nameof(ICoroutineManager));
            DontDestroyOnLoad(coroutineManagerGO);
            _coroutineManager = coroutineManagerGO.AddComponent<CoroutineManager>();
            _container.Register(_coroutineManager);

            _sceneLoader = new PlayerSceneLoader(_coroutineManager);
            _container.Register(_sceneLoader);

            _sceneLoader.LoadActiveSceneAsync(sceneName: "LootBox", LoadSceneMode.Single, LoadFinishedEventHandler);
        }

        private void LoadFinishedEventHandler(bool result)
        {
            Debug.Log($"LoadFinished: {result}");
        }
    }
}