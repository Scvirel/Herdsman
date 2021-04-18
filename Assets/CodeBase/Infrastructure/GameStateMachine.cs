﻿using System;
using System.Collections.Generic;

using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.ScenesLogic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> states;
        private IExitableState currentState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services)
        {
            states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, services.Single<ILevelFactory>())
            };
        }

        public void Enter<TState>() where TState : IState =>
            ChangeState<TState>().Enter();

        public void Enter<TState, TPayload>(TPayload payload) where TState : IPayloadedState<TPayload>
        {
            ChangeState<TState>().Enter(payload);
        }

        private TState ChangeState<TState>() where TState : IExitableState
        {
            currentState?.Exit();

            TState state = GetState<TState>();
            currentState = state;

            return state;
        }
        private TState GetState<TState>() where TState : IExitableState =>
            (TState)states[typeof(TState)];
    }
}