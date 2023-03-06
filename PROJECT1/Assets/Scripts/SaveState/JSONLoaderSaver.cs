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

    public static void SaveInventoryDataAsJSON(string savePath, string fname,
    InventoryData inventoryData)
    {
        Debug.Log("savePath: " + savePath);
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Creating save data directory: " + savePath);
        }
        string json = JsonUtility.ToJson(inventoryData);
        File.WriteAllText(savePath + fname, json);
    }

    public static InventoryData LoadInventoryDataFromJSON(string savePath, string
    fname)
    {
        if (File.Exists(savePath + fname))
        {
            string json = File.ReadAllText(savePath + fname);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(json);
            return inventoryData;
        }
        else
        {
            Debug.LogError("Cannot find file: " + savePath);
        }
        return null;
    }

    public static void SaveBossDefeatsDataAsJSON(string savePath, string fname,
    BossDefeatsData bossDefeatsData)
    {
        Debug.Log("savePath: " + savePath);
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Creating save data directory: " + savePath);
        }
        string json = JsonUtility.ToJson(bossDefeatsData);
        File.WriteAllText(savePath + fname, json);
    }

    public static BossDefeatsData LoadBossDefeatsDataFromJSON(string savePath, string
    fname)
    {
        if (File.Exists(savePath + fname))
        {
            string json = File.ReadAllText(savePath + fname);
            BossDefeatsData bossDefeatsData = JsonUtility.FromJson<BossDefeatsData>(json);
            return bossDefeatsData;
        }
        else
        {
            Debug.LogError("Cannot find file: " + savePath);
        }
        return null;
    }

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
