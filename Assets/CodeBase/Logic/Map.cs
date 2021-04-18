using CodeBase.Logic.LevelComponents;

using UnityEngine;

namespace CodeBase.Logic
{
    public class Map : MonoBehaviour
    {
        public Canvas MainCanvas;
        public GameField GameField;

        public void SetRenderCamera(Camera camera)
        {
            MainCanvas.worldCamera = camera;
        }
    }
}