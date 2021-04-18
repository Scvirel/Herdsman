using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.Factories
{
    public interface ILevelFactory : IService
    {
        void CreateLevel();
    }
}