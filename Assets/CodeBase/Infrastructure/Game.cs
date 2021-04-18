using CodeBase.Infrastructure.ScenesLogic;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
           GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}