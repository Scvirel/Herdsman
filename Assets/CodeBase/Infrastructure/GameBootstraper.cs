using CodeBase.Infrastructure.States;

using UnityEngine;

namespace CodeBase.Infrastructure
{
    //Entry point
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.GameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}