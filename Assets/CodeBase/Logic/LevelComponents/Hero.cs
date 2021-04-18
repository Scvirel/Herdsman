using System.Collections;

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

        public void Move(Vector2 position)
        {
            if (!_isMoving)
            {
                _destinationPosition = position;
                StartCoroutine(SmoothMove());
            }
        }

        private IEnumerator SmoothMove()
        {
            _isMoving = true;

            float elapsedTime = 0f;
            Vector2 currentPosition = MainRect.anchoredPosition;

            while (elapsedTime < _moveTime)
            {
                MainRect.anchoredPosition = Vector2.Lerp(currentPosition, currentPosition + _destinationPosition, elapsedTime / _moveTime);

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            _isMoving = false;
            yield return null;
        }
    }
}