using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/* Ended up not using this class. */

public class DataManagement : MonoBehaviour {

    public static DataManagement dataManagement;
    public int highScore;

    // singleton design pattern
    void Awake()
    {
        if (dataManagement == null)
        {
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        }
        else if (dataManagement != this)
        {
            Destroy(gameObject);
        }
    }//end awake

    public void saveData()
    {
        BinaryFormatter binFormatter = new BinaryFormatter(); // This creates a binary formatter.
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");// This creates file.
        gameData data = new gameData();// Creates container for data.
        data.highScore = highScore;
        binFormatter.Serialize(file, data);// Serializes the data into "gameInfo" file.
        file.Close();//close file
    }//end saveData

    public void loadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))// If there is data to load.
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open); // Opens requested file.
            gameData data = (gameData)binFormatter.Deserialize(file); // Decrypts data.
            file.Close();
            highScore = data.highScore;
        } // End if.
    } // End load data.
}

[Serializable]
class gameData {
    public int highScore;
}

