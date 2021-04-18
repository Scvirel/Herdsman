using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public class AnimalFactory : IAnimalFactory 
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ILevelMediator _gameMediator;
        public AnimalFactory(IAssetProvider assetProvider, ILevelMediator gameMediator)
        {
            _assetProvider = assetProvider;
            _gameMediator = gameMediator;
        }

        public GameObject CreateAnimal()
        {
            return _assetProvider.Initialize(AssetsPaths.AnimalPath);
        }

        public GameObject[] CreateAnimals(int count)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IAnimalFactory : IService
    {
        GameObject CreateAnimal();
        GameObject[] CreateAnimals(int count);
    }
}