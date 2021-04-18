using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CodeBase.Logic.LevelComponents
{
    public class Hero : LevelComponent
    {
        public RectTransform MainRect;
        public Camera MainCamera;

        public float _moveTime = 0.3f;
        private bool _isMoving;
        private Vector2 _destinationPosition;

        private int _maxAnimals = 5;
        private List<Animal> _group;

        private void Awake() =>
            _group = new List<Animal>();

        public void Move(Vector2 position)
        {
            if (!_isMoving)
            {
                _isMoving = true;
                _destinationPosition = position;
                StartCoroutine(SmoothMove(OnMoveComplete));
            }
        }

        private IEnumerator SmoothMove(Action onMoveComplete)
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

            onMoveComplete?.Invoke();
            yield return null;
        }

        public bool HasEmptySlots() =>
            _group.Count < 5;

        public void CatchAnimal(Animal animal)
        {
            animal.MainRect.parent = MainRect;

            _group.Add(animal);
        }

        private void OnMoveComplete()
        {
            _isMoving = false;
            Mediator.NotifyYard(_group, MainRect.anchoredPosition);
        }
    }
}