using UnityEngine;

namespace CodeBase.Infrastructure.AssetsManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Initialize(string path) =>
            Object.Instantiate(LoadResoursesPrefab(path));
        public GameObject Initialize(string path, Vector3 at) =>
            Object.Instantiate(LoadResoursesPrefab(path), at, Quaternion.identity);
        public GameObject Initialize(string path, Vector3 at, Transform parent) =>
            Object.Instantiate(LoadResoursesPrefab(path), at, Quaternion.identity, parent);

        private GameObject LoadResoursesPrefab(string path) =>
            Resources.Load<GameObject>(path);
    }
}
