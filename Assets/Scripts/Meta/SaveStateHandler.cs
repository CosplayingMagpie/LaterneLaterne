using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveStateHandler : MonoBehaviour
{
    private int intToSave;
    private int notherIntToSave;
    private string stringToSave;

    public static SaveStateHandler Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        else
        {
            Instance = this;
        }
    }

    public void SaveStats()
    {
        SaveData data = new SaveData();

        // ******************************
        //Dump all the variables that need saving in here
        data.intToSave = intToSave;
        data.notherIntToSave = notherIntToSave;
        data.stringToSave = stringToSave;
        // ******************************
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";

        File.WriteAllText(path, json);
        Debug.Log("Game saved");
    }

    public void LoadStats()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // ******************************
            //Dump all the variables that need loading in here
            intToSave = data.intToSave;
            notherIntToSave = data.notherIntToSave;
            stringToSave = data.stringToSave;
            // ******************************
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int intToSave;
        public int notherIntToSave;
        public string stringToSave;
    }
}
