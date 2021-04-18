using System;

using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.ScenesLogic;

using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    internal class LoadLevelState : IPayloadedState<string>
    {
        private const string _uiRootTag = "UIRoot";

        private GameStateMachine gameStateMachine;
        private SceneLoader sceneLoader;
        private ILevelFactory levelFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, ILevelFactory levelFactory)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.levelFactory = levelFactory;
        }

        public void Enter(string sceneName)
        {
            Debug.Log("LevelLoadState entered");
            sceneLoader.Load(sceneName, onLoaded: OnLevelLoaded);
        }

        public void Exit()
        {
            Debug.Log("LevelLoadState exited");
        }

        private void OnLevelLoaded()
        {
            InitLevel();
        }

        private void InitLevel()
        {
            levelFactory.CreateLevel();
        }
    }
}