using System;
using System.Collections.Generic;

using CodeBase.Logic.LevelComponents;

using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class LevelMediator : ILevelMediator
    {
        private List<Animal> _animals;

        private Hero _hero;
        private UserUI _userUI;
        private Yard _yard;

        public Hero Hero { set => _hero = value; }
        public UserUI UserUI { set => _userUI = value; }
        public Yard Yard { set => _yard = value; }

        public LevelMediator()
        {
            _animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal) =>
            _animals.Add(animal);
        public void ChangeHeroPosition(Vector2 position)
        {
            _hero.Move(position);
        }
    }
}