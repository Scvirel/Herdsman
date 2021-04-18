using System;
using System.Collections.Generic;

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

        void NotifyPatrolAnimals(Vector2 heroPosition);

        void OnAnimalCatchedByHero(Animal animal);

        void AddAnimal(Animal animal);
        void NotifyYard(List<Animal> group,Vector2 heroPosition);
        void AddPoints(int points);
    }
}