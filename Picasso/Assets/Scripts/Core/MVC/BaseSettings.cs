using UnityEngine;

namespace Assets.Scripts.Core.MVC
{
    [System.Serializable]
    public class BaseSettings : ScriptableObject
    {
        public const string MenuName = "Game Settings/";
        public const int Order = 2;
    }
}