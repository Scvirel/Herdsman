using System.Collections.Generic;

using UnityEngine;

namespace CodeBase.Logic.LevelComponents
{
    public class Yard : LevelComponent
    {
        public RectTransform MainRect;
        public float Range;

        private List<Animal> _animals;

        private void Awake() => 
            _animals = new List<Animal>();

        public void CheckToPut(List<Animal> group,Vector2 heroPosition)
        {
            for(int i = group.Count; i-- > 0;)
            {
                if (IsCollisionWithAnimal(group[i].MainRect.anchoredPosition + heroPosition))
                {
                    Animal collidedAnimal = group[i];
                    group.RemoveAt(i);

                    AnimalToYard(collidedAnimal);
                }
            }
        }

        private void AnimalToYard(Animal animal)
        {
            animal.MainRect.parent = MainRect;
            animal.SetYardState();

            _animals.Add(animal);
            Mediator.AddPoints(animal.Points);
        }
        private bool IsCollisionWithAnimal(Vector2 position) => 
            MainRect.anchoredPosition.x - Range <= position.x &&
            MainRect.anchoredPosition.x + Range >= position.x &&
            MainRect.anchoredPosition.y + Range >= position.y &&
            MainRect.anchoredPosition.y - Range <= position.y;
    }
}