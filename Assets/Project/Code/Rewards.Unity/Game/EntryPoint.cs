using Rewards.Container;
using Rewards.Coroutine;
using Rewards.Storage.SaveStrategy;
using Rewards.Storage.SaveStrategy.FileOperations;
using Rewards.UI.Management.Opener;
using Rewards.Unity.Coroutine.Manager;
using Rewards.Unity.LootBox.Config.SO;
using Rewards.Unity.SceneEntryPoint;
using Rewards.Unity.SceneEntryPoint.Provider;
using Rewards.Unity.SceneLoader;
using Rewards.Unity.UI.Management.Config;
using Rewards.Unity.UI.Management.Opener;
using Rewards.Unity.UI.Management.Opener.Layer.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rewards.Unity.Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private LootBoxCollectionConfigSO _lootBoxCollectionConfigSO;

        [SerializeField]
        private UIConfig _uiConfig;

        private string _currentSceneName;
        private string _saveDataPath;
        private IFileOperations _fileOperations;
        private ISaveStrategy _saveStrategy;
        private ICoroutineManager _coroutineManager;
        private ISceneLoader _sceneLoader;
        private ISceneEntryPointProvider _entryPointProvider;
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

            _entryPointProvider = new SceneEntryPointProvider();
            _container.Register(_entryPointProvider);

            _sceneLoader.LoadActiveSceneAsync(sceneName: "LootBox", LoadSceneMode.Single, LoadFinishedEventHandler);

            ILayerManager layerManager = new LayerManager(_uiConfig.Root);
            _container.Register(layerManager);
            IPanelOpener panelOpener = new PanelOpener(layerManager, _uiConfig);
            _container.Register(panelOpener);
        }

        private void LoadFinishedEventHandler(bool result)
        {
            Debug.Log($"LoadFinished: {result}");
            var entryPoint = _entryPointProvider.Find<LootBoxSceneEntryPoint>();
            entryPoint.Enter(_container);
        }
    }
}