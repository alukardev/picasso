using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InventoryView : BaseView
    {
        public InventoryViewItem ItemPrefab;
        public Transform ItemsParent;
        public List<Color> Colors;

        private List<InventoryViewItem> _items;
        private GameManager _gameManager;

        void Awake()
        {
            _items = new List<InventoryViewItem>();
            _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }

        void Start()
        {
            foreach (var color in Colors)
            {
                var item = Instantiate(ItemPrefab, ItemsParent);
                item.Init(_gameManager);
                item.SetColor(color);
                item.OnSelect += OnItemSelect;
                _items.Add(item);
            }

            _items[0].Select();
        }

        private void OnItemSelect(InventoryViewItem viewItem)
        {
            foreach (var inventoryViewItem in _items)
            {
                if(inventoryViewItem != viewItem)
                    inventoryViewItem.Unselect();
            }
        }

        public Color GetCurrentColor()
        {
            foreach (var inventoryViewItem in _items)
            {
                if (inventoryViewItem.IsSelected)
                    return inventoryViewItem.GetColor();
            }

            return _items[0].GetColor();
        }
    }
}