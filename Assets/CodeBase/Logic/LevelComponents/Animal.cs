using UnityEngine;

namespace CodeBase.Logic.LevelComponents
{
    public class Animal : LevelComponent
    {
        public RectTransform MainRect;
        public float Range;
        public int Points;

        public void NotifyPatrolByHeroPosition(Vector2 position)
        {
            if (IsCollisionWithHero(position))
            {
                Mediator.OnAnimalCatchedByHero(this);
            }
        }

        public void NotifyFollowByHeroPosition(Vector2 positionChange) => 
            MainRect.anchoredPosition += positionChange;

        private bool IsCollisionWithHero(Vector2 position) =>
            MainRect.anchoredPosition.x - Range <= position.x &&
            MainRect.anchoredPosition.x + Range >= position.x &&
            MainRect.anchoredPosition.y + Range >= position.y &&
            MainRect.anchoredPosition.y - Range <= position.y;
    }
}