using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Logic.LevelComponents
{
    public class LevelComponent : MonoBehaviour
    {
        private ILevelMediator _gameMediator;
        public ILevelMediator GameMediator => _gameMediator;

        public void Subscribe(ILevelMediator gameMediator) => 
            _gameMediator = gameMediator;
    }
}