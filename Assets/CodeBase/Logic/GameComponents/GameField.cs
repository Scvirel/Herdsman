using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Logic.GameComponents
{
    public class GameField : GameComponent, IPointerDownHandler
    {
        public Transform HeroSpawnPoint;
        public Transform YardSpawnPoint;

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Pointer down catch");
        }
    }
}