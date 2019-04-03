using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputController : MonoBehaviour
    {
        public Action<bool> OnTouch;

        private bool _isPressed;

        void Start()
        {
        
        }

        void Update()
        {
#if UNITY_EDITOR
            OnMouseInput();
#else
            OnMobileInput();
#endif
        }

        private void OnMobileInput()
        {
            if (Input.touchCount <= 0)
                return;

            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("start touch");
                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    Debug.Log("End touch");
                    break;
            }
        }

        private void OnMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!_isPressed)
                {
                    _isPressed = true;
                    OnTouch?.Invoke(true);

                    Debug.Log("start touch");
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (_isPressed)
                {
                    _isPressed = false;
                    OnTouch?.Invoke(false);

                    Debug.Log("End touch");
                }
            }
        }
    }
}