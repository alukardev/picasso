using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.Core.MVC;
using UnityEngine;

namespace Assets.Scripts.Core.Data
{
    public class DataSaver<T> : Singleton<DataSaver<T>> where T : IDataStore
    {
        private const string FileName = "GameSave.gd";

        public void Save(T data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(Application.persistentDataPath, FileName), FileMode.OpenOrCreate);
            bf.Serialize(file, data);
            file.Close();
            Debug.Log(Application.persistentDataPath + " " + FileName);
        }

        public bool Load(out T data)
        {
            if (File.Exists(Path.Combine(Application.persistentDataPath, FileName)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Path.Combine(Application.persistentDataPath, FileName), FileMode.Open);
                data = (T)bf.Deserialize(file);
                file.Close();

                return true;
            }

            data = default(T);
            return false;
        }
    }
}