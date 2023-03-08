using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
public class BinaryLoaderSaver : MonoBehaviour
{
    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }
    public static void SavePlayerAsBinary(string savePath, string fname, PlayerData
    playerData)
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Creating save data directory: " + savePath);
        }
        FileStream file = File.Create(savePath + fname);
        BinaryFormatter formatter = GetBinaryFormatter();
        formatter.Serialize(file, playerData);
        file.Close();
    }
    public static PlayerData LoadPlayerFromBinary(string savePath, string fname)
    {
        if (File.Exists(savePath + fname))
        {
            BinaryFormatter formatter = GetBinaryFormatter();
            FileStream file = File.Open(savePath + fname, FileMode.Open);
            PlayerData playerData = null;
            try
            {
                playerData = (PlayerData)formatter.Deserialize(file);
            }
            catch
            {
                Debug.LogError("File format error: " + savePath);
            }
            finally
            {
                file.Close();
            }
            return playerData;
        }
        else
        {
            Debug.LogError("Cannot find file: " + savePath);
        }
        return null;
    }
}
