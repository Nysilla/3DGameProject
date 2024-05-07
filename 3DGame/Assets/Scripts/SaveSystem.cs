using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static string keyWord = "To you, Gwendolyne, my love, its been so long since we have seen each other, after I left for the war you said you would be waiting for me, I bought some land at the city of Turku, in Finland, and build ourselfs a lovely lighthouse to house the little ones, I do desparetly wait your return. Forever love -Jack";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            Load();
        }
    }

    public void Save()
    { 
        SaveData myData = new SaveData();
        myData.X = transform.position.x;
        myData.Y = transform.position.y;
        myData.Z = transform.position.z;
        string myDataString = JsonUtility.ToJson(myData);
        string file = Application.persistentDataPath + "/" + gameObject.name + ".json";
        File.WriteAllText(file, EncryptDecryptData(myDataString));
    }

    public void Load()
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + ".json";
        if (!File.Exists(file))
        {
            return;
        }
        string jsonData = File.ReadAllText(file);
        SaveData myData = JsonUtility.FromJson<SaveData>(EncryptDecryptData(jsonData));
        transform.position = new Vector3(myData.X, myData.Y, myData.Z);
    }

    public string EncryptDecryptData(string data)
    {
        string result = string.Empty;
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ keyWord[i % keyWord.Length]);
        }
        return result;
    }
}

[System.Serializable]
public class SaveData
{
    public float X;
    public float Y;
    public float Z;
}