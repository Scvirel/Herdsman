using System;

using CodeBase.Logic.LevelComponents;

using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public interface ILevelMediator : IService
    {
        Hero Hero {set; }
        UserUI UserUI {set; }
        Yard Yard { set; }

        void ChangeHeroPosition(Vector2 position);

        void AddAnimal(Animal animal);
    }
}