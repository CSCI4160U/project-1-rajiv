using UnityEngine;
using System.IO;
public class JSONLoaderSaver : MonoBehaviour
{
    //public static void SaveArmourAsJSON(string savePath, string fname, Armour
    //armour)
    //{
    //    Debug.Log("savePath: " + savePath);
    //    if (!Directory.Exists(savePath))
    //    {
    //        Directory.CreateDirectory(savePath);
    //        Debug.Log("Creating save data directory: " + savePath);
    //    }
    //    string json = JsonUtility.ToJson(armour);
    //    File.WriteAllText(savePath + fname, json);
    //}
    //public static Armour LoadArmourFromJSON(string savePath, string fname)
    //{
    //    if (File.Exists(savePath + fname))
    //    {
    //        string json = File.ReadAllText(savePath + fname);
    //        Armour armour = JsonUtility.FromJson<Armour>(json);
    //        return armour;
    //    }
    //    else
    //    {
    //        Debug.LogError("Cannot find file: " + savePath);
    //    }
    //    return null;
    //}
    public static void SavePlayerDataAsJSON(string savePath, string fname,
    PlayerData playerData)
    {
        Debug.Log("savePath: " + savePath);
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Creating save data directory: " + savePath);
        }
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(savePath + fname, json);
    }

    public static PlayerData LoadPlayerDataFromJSON(string savePath, string
    fname)
    {
        if (File.Exists(savePath + fname))
        {
            string json = File.ReadAllText(savePath + fname);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            return playerData;
        }
        else
        {
            Debug.LogError("Cannot find file: " + savePath);
        }
        return null;
    }

    public static void SaveSceneDataAsJSON(string savePath, string fname,
    SceneData sceneData)
    {
        Debug.Log("savePath: " + savePath);
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Creating save data directory: " + savePath);
        }
        string json = JsonUtility.ToJson(sceneData);
        File.WriteAllText(savePath + fname, json);
    }

    public static SceneData LoadSceneDataFromJSON(string savePath, string
    fname)
    {
        if (File.Exists(savePath + fname))
        {
            string json = File.ReadAllText(savePath + fname);
            SceneData sceneData = JsonUtility.FromJson<SceneData>(json);
            return sceneData;
        }
        else
        {
            Debug.LogError("Cannot find file: " + savePath);
        }
        return null;
    }
}