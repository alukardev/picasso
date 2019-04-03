using UnityEngine;

namespace Assets.Scripts.UI
{
    public class BaseView : MonoBehaviour
    {
        protected GameManager GameManager;

        public void Init(GameManager gameManager)
        {
            GameManager = gameManager;
        }
    }
}