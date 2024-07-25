using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class StoredStats : MonoBehaviour
{
    int runningStat;
    int swimmingStat;
    int climbingStat;
    int flyingStat;
    
    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
                    + "/MySaveData.dat"); 
        SaveData data = new SaveData();
        data.savedRunningStat = runningStat;
        data.savedSwimmingStat = swimmingStat;
        data.savedClimbingStat = climbingStat;
        data.savedFlyingStat = flyingStat;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath 
                    + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                    File.Open(Application.persistentDataPath 
                    + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            runningStat = data.savedRunningStat;
            swimmingStat = data.savedSwimmingStat;
            climbingStat = data.savedClimbingStat;
            flyingStat = data.savedFlyingStat;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

[Serializable]
class SaveData
{
    public int savedRunningStat;
    public int savedSwimmingStat;
    public int savedClimbingStat;
    public int savedFlyingStat;
}
