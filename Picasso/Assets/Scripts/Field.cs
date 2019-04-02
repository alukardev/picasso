using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Field : MonoBehaviour
    {
        public FieldSettings Settings;

        private List<GameObject> _cells;

        void Awake()
        {
            _cells = new List<GameObject>();
        }

        void Start()
        {
            Prepare();
        }

        private void Prepare()
        {
            for (int i = 0; i < Settings.Height; i++)
            {
                for (int j = 0; j < Settings.Width; j++)
                {
                    var cell = Instantiate(Settings.CellPrefab);
                    cell.transform.position += new Vector3(Settings.CellPositionOffset * j, Settings.CellPositionOffset * i, 0);
                    _cells.Add(cell);
                }
            }
        }
    }
}