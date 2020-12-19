using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    public BagScriptableObj playerBag;

    public void Save()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");
        }
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/SaveData/playerBag");
        var json = JsonUtility.ToJson(playerBag);
        bf.Serialize(file, json);

        file.Close();
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/SaveData/playerBag"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData/playerBag", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), playerBag);

            file.Close();
        }
    }
}
