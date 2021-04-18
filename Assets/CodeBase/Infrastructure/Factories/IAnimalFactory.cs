using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IAnimalFactory : IService
    {
        void StartAnimalsCreatingIn(Transform parent,RectTransform gameField);
    }
}