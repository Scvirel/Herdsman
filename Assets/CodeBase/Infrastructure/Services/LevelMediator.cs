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

        public LevelMediator() => 
            _animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            animal.Subscribe(this);
            _animals.Add(animal);
        }
        public void ChangeHeroPosition(Vector2 position) => 
            _hero.Move(position);
        public void NotifyPatrolAnimals(Vector2 position)
        {
            for (int i = 0; i < _animals.Count; i++)
            {
                _animals[i].NotifyPatrolByHeroPosition(position);
            }
        }
        public void OnAnimalCatchedByHero(Animal animal)
        {
            if (_hero.HasEmptySlots())
            {
                _animals.Remove(animal);
                _hero.CatchAnimal(animal);
            }
        }
        public void NotifyYard(List<Animal> group, Vector2 heroPosition) => 
            _yard.CheckToPut(group, heroPosition);
        public void AddPoints(int points) => 
            _userUI.AddScore(points);
    }
}