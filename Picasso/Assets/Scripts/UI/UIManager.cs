using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UiManager : MonoBehaviour
    {
        public ColorPicker ColorPicker;
        public GameObject ColorPickerBack;

        public void ShowColorPicker(bool isShow)
        {
            ColorPicker.gameObject.SetActive(isShow);
            ColorPickerBack.SetActive(isShow);
        }

        public bool ColorPickerIsActive()
        {
            return ColorPicker.gameObject.activeSelf;
        }
    }
}