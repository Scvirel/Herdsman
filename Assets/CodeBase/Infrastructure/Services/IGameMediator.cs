using CodeBase.Logic.GameComponents;

namespace CodeBase.Infrastructure.Services
{
    public interface IGameMediator : IService
    {
        Hero Hero {set; }
        UserUI UserUI {set; }
        Yard Yard { set; }

        void AddAnimal(Animal animal);
    }
}