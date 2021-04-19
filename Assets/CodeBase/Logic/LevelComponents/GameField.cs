using System;

using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Logic.LevelComponents
{
    public class GameField : LevelComponent, IPointerDownHandler
    {
        public RectTransform MainRect;

        public Transform HeroSpawnPoint;
        public Transform YardSpawnPoint;

        private Vector2 _cameraSize;

        public void OnPointerDown(PointerEventData downEvent)
        {
            if (_cameraSize == Vector2.zero)
            {
                _cameraSize = GetCameraSize(downEvent.enterEventCamera);
            }

            Mediator.ChangeHeroPosition(downEvent.position - _cameraSize / 2f);
        }

        private Vector2 GetCameraSize(Camera camera) =>
            new Vector2(camera.pixelWidth, camera.pixelHeight);
    }
}