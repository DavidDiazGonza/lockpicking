using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class SaverManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "LockPickData.txt";

    public static void Save(SavedData savedData)
    {
        string dir = Application.streamingAssetsPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(savedData,true);
        File.WriteAllText(dir + fileName, json);
    }

    public static SavedData Load()
    {
        string fullPath = Application.streamingAssetsPath + directory + fileName;
        SavedData savedData = new SavedData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            savedData = JsonUtility.FromJson<SavedData>(json);
        }
        else
        {
            Debug.LogError("Save file does not exist");
        }

        return savedData;
    }
}

[System.Serializable]
public class SavedData
{
    public List<Level> levels;

    public SavedData(List<Level> levels = null)
    {
        this.levels = levels;
    }
}
