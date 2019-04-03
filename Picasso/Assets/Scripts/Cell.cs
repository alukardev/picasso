using UnityEngine;

namespace Assets.Scripts
{
    public class Cell : MonoBehaviour
    {
        public SpriteRenderer Renderer;

        public void SetColor(Color color)
        {
            Renderer.color = color;
        }
    }
}