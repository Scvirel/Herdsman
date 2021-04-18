using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Infrastructure.AssetsManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Initialize(string path);
        GameObject Initialize(string path, Vector3 at);
        GameObject Initialize(string path, Vector3 at, Transform parent);
    }
}
