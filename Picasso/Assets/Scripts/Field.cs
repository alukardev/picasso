using System.Collections.Generic;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class Field : MonoBehaviour
    {
        public FieldSettings Settings;
        public InventoryView InventoryView;

        private List<Cell> _cells;
        private GameManager _gameManager;
        private bool _isDrawing;
        private float _drawDelay;
        private int _currentCellIndex;

        void Awake()
        {
            _cells = new List<Cell>();
            _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            _gameManager.Input.OnTouch += OnTouch;

            _drawDelay = Settings.DrawDelay;
        }

        void Start()
        {
            SnailFill();
            transform.localPosition = Settings.Position;
        }

        private void SnailFill()
        {
            var n = Settings.Size;
            short steps = 1;


            for (short i = n, j = n; i >= 0; i--, j++)
            {
                if (steps == 1)
                {
                    steps += 2;
                    CreateCell(i, j);
                }
                else
                {
                    int x = i;
                    var y = j;

                    for(x = i + 1; x < i + steps; x++)
                        CreateCell(x, y);

                    x--;
                    var startY = j - 1;
                    for(y = (short)startY; y > j - steps; y--)
                        CreateCell(x, y);

                    y++;
                    var startX = i + steps - 2;
                    for (x = (short)startX; x >= i; x--)
                        CreateCell(x, y);

                    x++;
                    startY = j - steps + 2;
                    for (y = (short)startY; y < j; y++)
                        CreateCell(x, y);

                    CreateCell(i, y);

                    steps += 2;
                }
            }
        }

        private void CreateCell(float x, float y)
        {
            var cell = Instantiate(Settings.CellPrefab, transform);
            cell.transform.position += new Vector3(Settings.CellPositionOffset * x, Settings.CellPositionOffset * y, 0);
            cell.transform.name = "Cell_" + x + "_" + y;
            _cells.Add(cell.GetComponent<Cell>());
        }

        void Update()
        {
            if (_isDrawing)
            {
                if(_currentCellIndex >= _cells.Count)
                    return;

                _drawDelay += Time.deltaTime;

                if (_drawDelay >= Settings.DrawDelay)
                {
                    _cells[_currentCellIndex].SetColor(InventoryView.GetCurrentColor());

                    _drawDelay = 0;
                    _currentCellIndex++;
                }
            }
        }

        private void OnTouch(bool isStart)
        {
            if(isStart)
                StartDraw();
            else
                StopDraw();
        }

        private void StartDraw()
        {
            if(_isDrawing)
                return;


            _isDrawing = true;
        }

        private void StopDraw()
        {
            if(!_isDrawing)
                return;

            _isDrawing = false;
            _drawDelay = Settings.DrawDelay;
        }
    }
}