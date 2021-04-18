using Assets.CodeBase.Infrastructure.Factories;

using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.ScenesLogic;
using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            Debug.Log("BootstrapState entered");
            _sceneLoader.Load(ScenesPaths.Initial, onLoaded: EnterLevelLoad);
        }

        public void Exit()
        {
            Debug.Log("BootstrapState exited");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());

            _services.RegisterSingle<IRandomService>(new RandomService());

            _services.RegisterSingle<IGameMediator>(new GameMediator());

            _services.RegisterSingle<IMainHeroFactory>(new MainHeroFactory(_services.Single<IAssetProvider>()));

            _services.RegisterSingle<IAnimalFactory>(new AnimalFactory(_services.Single<IAssetProvider>(),_services.Single<IGameMediator>()));

            _services.RegisterSingle<ILevelFactory>(new LevelFactory(_services.Single<IAssetProvider>(),_services.Single<IMainHeroFactory>(),_services.Single<IAnimalFactory>(),_services.Single<IGameMediator>()));
        }

        private void EnterLevelLoad()
        {
            _stateMachine.Enter<LoadLevelState, string>(ScenesPaths.LevelPath(1));
        }
    }
}