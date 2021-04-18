using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Logic.GameComponents
{
    public class GameComponent : MonoBehaviour
    {
        private IGameMediator _gameMediator;
        public IGameMediator GameMediator => _gameMediator;

        public void Subscribe(IGameMediator gameMediator) => 
            _gameMediator = gameMediator;
    }
}