using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Logic.LevelComponents
{
    public class GameField : LevelComponent, IPointerDownHandler
    {
        public RectTransform ParentRect;

        public Transform HeroSpawnPoint;
        public Transform YardSpawnPoint;

        public void OnPointerDown(PointerEventData downEvent)
        {
            Debug.Log("Pointer down catch");

            GameMediator.ChangeHeroPosition(downEvent.position - ParentRect.anchoredPosition);
        }
    }
}