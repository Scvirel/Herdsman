using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Logic.LevelComponents
{
    public class LevelComponent : MonoBehaviour
    {
        private ILevelMediator _mediator;
        public ILevelMediator Mediator => _mediator;

        public void Subscribe(ILevelMediator gameMediator) =>
            _mediator = gameMediator;
    }
}