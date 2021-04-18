using UnityEngine;

namespace CodeBase.Logic
{
    public class Map : MonoBehaviour
    {
        public Canvas MainCanvas;

        public void SetRenderCamera(Camera camera)
        {
            MainCanvas.worldCamera = camera;
        }
    }
}