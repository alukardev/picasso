using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InventoryViewItem : MonoBehaviour
    {
        public Image ImageColor;
        public Image SelectedImage;

        public Action<InventoryViewItem> OnSelect;
        private Color _color;

        public bool IsSelected { get; private set; }

        void Awake()
        {
            SelectedImage.enabled = false;
        }

        public void SetColor(Color color)
        {
            ImageColor.color = color;
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
        }

        public void Select()
        {
            if(IsSelected)
                return;

            IsSelected = true;
            SelectedImage.enabled = true;

            OnSelect?.Invoke(this);
        }

        public void Unselect()
        {
            SelectedImage.enabled = false;
            IsSelected = false;
        }
    }
}