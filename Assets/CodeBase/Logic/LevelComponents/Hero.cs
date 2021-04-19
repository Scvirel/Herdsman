using System;
using System.Collections;
using System.Collections.Generic;

using CodeBase.Infrastructure;

using UnityEngine;

namespace CodeBase.Logic.LevelComponents
{
    public class Hero : LevelComponent
    {
        public RectTransform MainRect;
        public Camera MainCamera;

        public float _moveTime = 0.3f;

        private bool _isMoving;
        private bool _isYardReporting;
        private int _maxAnimals = 5;

        private Vector2 _destinationPosition;

        private ICoroutineRunner _coroutineRunner;

        private List<Animal> _group;
        private Coroutine _yardReporting;
        private Coroutine _smoothMove;

        public void Construct(ICoroutineRunner coroutineRunner)
        {
            _group = new List<Animal>();
            _coroutineRunner = coroutineRunner;
        }

        public void StartYardReporting()
        {
            _isYardReporting = true;
            _yardReporting = _coroutineRunner.StartCoroutine(YardReporting());
        }
        public void Move(Vector2 position)
        {
            if (!_isMoving)
            {
                _isMoving = true;
                _destinationPosition = position;
                _smoothMove = _coroutineRunner.StartCoroutine(SmoothMove());
            }
        }
        public bool HasEmptySlots() =>
            _group.Count < _maxAnimals;
        public void CatchAnimal(Animal animal)
        {
            if (!_isYardReporting)
            {
                StartYardReporting();
            }

            animal.MainRect.parent = MainRect;
            animal.SetHeroFollowState();

            _group.Add(animal);
        }

        private IEnumerator SmoothMove()
        {
            float elapsedTime = 0f;
            Vector2 currentPosition = MainRect.anchoredPosition;

            while (elapsedTime < _moveTime)
            {
                MainRect.anchoredPosition = Vector2.Lerp(currentPosition, currentPosition + _destinationPosition, elapsedTime / _moveTime);
                Mediator.NotifyPatrolAnimals(MainRect.anchoredPosition);

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            _isMoving = false;

            yield return null;
        }
        private IEnumerator YardReporting()
        {
            while (true)
            {
                Mediator.NotifyYard(_group, MainRect.anchoredPosition);

                yield return true;
            }
        }
    }
}