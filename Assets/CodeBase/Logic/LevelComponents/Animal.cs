using System.Collections;

using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;

using UnityEngine;

namespace CodeBase.Logic.LevelComponents
{
    public class Animal : LevelComponent
    {
        public RectTransform MainRect;
        public float Range;
        public int Points;

        public float RotationRadius;
        public float RotationSpeed;

        private IRandomService _randomService;
        private ICoroutineRunner _coroutineRunner;

        private Vector2 _rotationCenter;
        private float _rotationAngle;

        private Coroutine _circleRotation;

        public void Construct(IRandomService randomService, ICoroutineRunner coroutineRunner)
        {
            _randomService = randomService;
            _coroutineRunner = coroutineRunner;

            _rotationCenter = MainRect.anchoredPosition - new Vector2(RotationRadius, RotationRadius);
            _circleRotation = _coroutineRunner.StartCoroutine(CircleRotate());
        }

        public void NotifyPatrolByHeroPosition(Vector2 position)
        {
            if (IsCollisionWithHero(position))
            {
                Mediator.OnAnimalCatchedByHero(this);
            }
        }
        public void NotifyFollowByHeroPosition(Vector2 heroPositionChange) =>
            MainRect.anchoredPosition += heroPositionChange;
        public void SetHeroFollowState()
        {
            _rotationCenter = Vector2.zero;
            RotationRadius *= 2.5f;
            RotationSpeed *= 2f;
        }
        public void SetYardState()
        {
            _rotationCenter = Vector2.zero;
            RotationRadius = _randomService.Next(100, 200);
            RotationSpeed = _randomService.Next(2, 10);
        }

        private bool IsCollisionWithHero(Vector2 position) =>
            MainRect.anchoredPosition.x - Range <= position.x &&
            MainRect.anchoredPosition.x + Range >= position.x &&
            MainRect.anchoredPosition.y + Range >= position.y &&
            MainRect.anchoredPosition.y - Range <= position.y;
        private IEnumerator CircleRotate()
        {
            Vector2 rotationPosition = Vector2.zero;

            while (true)
            {
                _rotationAngle += Time.deltaTime;

                rotationPosition.x = Mathf.Cos(_rotationAngle * RotationSpeed) * RotationRadius;
                rotationPosition.y = Mathf.Sin(_rotationAngle * RotationSpeed) * RotationRadius;

                MainRect.anchoredPosition = rotationPosition + _rotationCenter;

                yield return null;
            }
        }
    }
}