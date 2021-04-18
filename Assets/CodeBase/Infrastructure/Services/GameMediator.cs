using System.Collections.Generic;

using CodeBase.Logic.GameComponents;

namespace CodeBase.Infrastructure.Services
{
    public class GameMediator : IGameMediator
    {
        private List<Animal> _animals;

        private Hero _hero;
        private UserUI _userUI;
        private Yard _yard;

        public Hero Hero { set => _hero = value; }
        public UserUI UserUI { set => _userUI = value; }
        public Yard Yard { set => _yard = value; }

        public GameMediator() =>
            _animals = new List<Animal>();

        public void AddAnimal(Animal animal) =>
            _animals.Add(animal);
    }
}