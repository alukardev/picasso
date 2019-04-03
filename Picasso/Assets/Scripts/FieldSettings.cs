using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New Field Settings", menuName = "Picasso/Field Settings", order = 51)]
    public class FieldSettings : ScriptableObject
    {
        [Tooltip("Real matrix size = 2*Size + 1")]
        public short Size;
        public Vector3 Position;
        public float DrawDelay;
        public GameObject CellPrefab;
        public float CellPositionOffset;
    }
}