using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InventoryViewItem : BaseView
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

        void Start()
        {
            GameManager.UI.ColorPicker.onValueChanged.AddListener(OnColorPickerChange);
        }

        private void OnColorPickerChange(Color color)
        {
            if (IsSelected)
            {
                _color = color;
                ImageColor.color = color;
            }
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

        public void OnItemClick()
        {
            if (IsSelected)
            {
                ShowColorPicker();
            }
            else
            {
                Select();
            }
        }

        private void ShowColorPicker()
        {
            var isActive = GameManager.UI.ColorPickerIsActive();
            GameManager.UI.ShowColorPicker(!isActive);
            if(!isActive)
                GameManager.UI.ColorPicker.CurrentColor = _color;
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
            GameManager.UI.ShowColorPicker(false);
        }
    }
}