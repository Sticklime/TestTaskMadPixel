using CodeBase.Infrastructure.Services.ConfigProvider;
using UnityEngine;

namespace CodeBase.Infrastructure.Boot
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private IProgressProvider _progressProvider;
        private IConfigProvider _configProvider;
        private ISceneLoader _sceneLoader;
        private IUIFactory _uiFactory;
        private Game _game;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _progressProvider = new ProgressProvider();
            _configProvider = new ConfigProvider();
            _sceneLoader = new SceneLoader(this);
            _uiFactory = new UIFactory(_progressProvider, _configProvider);

            _configProvider.Load();
            _uiFactory.Load();

            _game = new Game(_uiFactory, _sceneLoader);

            _game.StartGame();
        }
    }
}