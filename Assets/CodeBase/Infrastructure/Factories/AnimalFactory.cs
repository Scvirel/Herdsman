using System.Collections;

using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic.LevelComponents;

using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ILevelMediator _levelMediator;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IRandomService _randomService;

        private Transform _animalsParent;
        private Coroutine _spawningAnimals;

        private float _heightMaxValue, _heightMinValue;
        private float _widthMaxValue, _widthMinValue;
        private float _timeMax = 1f, _timeMin = 5f;

        public AnimalFactory(IAssetProvider assetProvider, ILevelMediator levelMediator, ICoroutineRunner coroutineRunner, IRandomService randomService)
        {
            _assetProvider = assetProvider;
            _levelMediator = levelMediator;
            _coroutineRunner = coroutineRunner;
            _randomService = randomService;
        }

        public void StartAnimalsCreatingIn(Transform parent, RectTransform gameField)
        {
            _heightMaxValue = Mathf.Abs(gameField.rect.y);
            _heightMinValue = _heightMaxValue - 800f;

            _widthMaxValue = Mathf.Abs(gameField.rect.x);
            _widthMinValue = _widthMaxValue - 1200f;

            _animalsParent = parent;

            _spawningAnimals = _coroutineRunner.StartCoroutine(AnimalSpawning());
        }
        public void StopAnimalsCreating() =>
            _coroutineRunner.StopCoroutine(_spawningAnimals);

        private IEnumerator AnimalSpawning()
        {
            while (true)
            {
                Animal spawnedAnimal = _assetProvider.Initialize(AssetsPaths.AnimalPath, Vector3.zero, _animalsParent).GetComponent<Animal>();

                spawnedAnimal.MainRect.anchoredPosition = GeneratePosition();
                spawnedAnimal.Construct(_randomService, _coroutineRunner);

                _levelMediator.AddAnimal(spawnedAnimal);

                yield return new WaitForSecondsRealtime(GenerateTime());
            }
        }
        private Vector2 GeneratePosition()
        {
            Vector2 generatedPosition;

            generatedPosition.x = _randomService.Next(0, 2) == 0 ? GenerateWidth() : -GenerateWidth();
            generatedPosition.y = _randomService.Next(0, 2) == 0 ? GenerateHeight() : -GenerateHeight();

            return generatedPosition;
        }
        private float GenerateWidth() =>
            _randomService.Next(_widthMinValue, _widthMaxValue);
        private float GenerateHeight() =>
            _randomService.Next(_heightMinValue, _heightMaxValue);
        private float GenerateTime() =>
            _randomService.Next(_timeMin, _timeMax);
    }
}