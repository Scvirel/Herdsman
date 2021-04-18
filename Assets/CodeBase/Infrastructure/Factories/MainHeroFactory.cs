using CodeBase.Infrastructure.AssetsManagement;

using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factories
{
    public class MainHeroFactory : IMainHeroFactory
    {
        private readonly IAssetProvider _assetProvider;

        public MainHeroFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateMainHero(Vector3 at, Transform parent) => 
            _assetProvider.Initialize(AssetsPaths.UserHeroPath, at, parent);
    }
}