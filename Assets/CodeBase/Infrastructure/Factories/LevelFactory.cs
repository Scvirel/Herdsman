using Assets.CodeBase.Infrastructure.Factories;

using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using CodeBase.Logic.LevelComponents;

using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public class LevelFactory : ILevelFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IMainHeroFactory _mainHeroFactory;
        private readonly IAnimalFactory _animalFactory;
        private readonly ILevelMediator _gameMediator;
        private readonly ICoroutineRunner _coroutineRunner;

        private UserUI _userUI;
        private GameField _gameField;
        private Hero _hero;
        private Yard _yard;

        public LevelFactory(IAssetProvider assetProvider, IMainHeroFactory mainHeroFactory, IAnimalFactory animalFactory, ILevelMediator gameMediator, ICoroutineRunner coroutineRunner)
        {
            _mainHeroFactory = mainHeroFactory;
            _animalFactory = animalFactory;
            _assetProvider = assetProvider;
            _gameMediator = gameMediator;
            _coroutineRunner = coroutineRunner;
        }

        public void CreateLevel()
        {
            _userUI = CreateUserInterface().GetComponent<UserUI>();

            GameObject mapObj = CreateMap();
            Map map = mapObj.GetComponent<Map>();

            _gameField = map.GameField;

            _yard = CreateYard(_gameField.YardSpawnPoint.position, mapObj.transform).GetComponent<Yard>();

            _hero = CreateHero(_gameField.HeroSpawnPoint.position, mapObj.transform).GetComponent<Hero>();
            _hero.Construct(_coroutineRunner);

            _animalFactory.StartAnimalsCreatingIn(mapObj.transform, _gameField.MainRect);

            map.SetRenderCamera(_hero.MainCamera);

            SubscribeMediator();
        }

        private GameObject CreateMap() =>
            _assetProvider.Initialize(AssetsPaths.MapUIRootPath);
        private GameObject CreateUserInterface() =>
            _assetProvider.Initialize(AssetsPaths.UserUIRootPath);
        private GameObject CreateGameField(Transform parent) =>
            _assetProvider.Initialize(AssetsPaths.GameFieldPath, Vector3.zero, parent);
        private GameObject CreateHero(Vector3 spawnPosition, Transform parent) =>
            _mainHeroFactory.CreateMainHero(spawnPosition, parent);
        private GameObject CreateYard(Vector3 position, Transform parent) =>
            _assetProvider.Initialize(AssetsPaths.YardPath, position, parent);

        private void SubscribeMediator()
        {
            _gameMediator.Hero = _hero;
            _gameMediator.Yard = _yard;
            _gameMediator.UserUI = _userUI;

            _userUI.Subscribe(_gameMediator);
            _gameField.Subscribe(_gameMediator);
            _hero.Subscribe(_gameMediator);
            _yard.Subscribe(_gameMediator);
        }
    }
}