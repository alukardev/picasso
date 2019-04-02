using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New Field Settings", menuName = "Picasso/Field Settings", order = 51)]
    public class FieldSettings : ScriptableObject
    {
        public short Width;
        public short Height;
        public GameObject CellPrefab;
        public float CellPositionOffset;
    }
}