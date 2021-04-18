using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factories
{
    public interface IMainHeroFactory : IService
    {
        GameObject CreateMainHero(Vector3 at,Transform parent);
    }
}