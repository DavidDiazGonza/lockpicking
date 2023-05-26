using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class SaverManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "LockPickData.txt";

    public static void Save(Level level)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(level);
        File.WriteAllText(dir + fileName, json);
    }

    public static Level Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        Level level = new Level();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            level = JsonUtility.FromJson<Level>(json);
        }
        else
        {
            Debug.LogError("Save file does not exist");
        }

        return level;
    }

}
