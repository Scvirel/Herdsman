﻿using System.Collections.Generic;

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
                    collidedAnimal.MainRect.parent = MainRect;
                    _animals.Add(collidedAnimal);
                    Mediator.AddPoints(collidedAnimal.Points);
                }
            }
        }

        public bool IsCollisionWithAnimal(Vector2 position) => 
            MainRect.anchoredPosition.x - Range <= position.x &&
            MainRect.anchoredPosition.x + Range >= position.x &&
            MainRect.anchoredPosition.y + Range >= position.y &&
            MainRect.anchoredPosition.y - Range <= position.y;
    }
}