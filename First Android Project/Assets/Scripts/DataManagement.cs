using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        BinaryFormatter binFormatter = new BinaryFormatter(); // this creates a binary formatter
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");// this creates file
        gameData data = new gameData();// creates container for data
        data.highScore = highScore;
        binFormatter.Serialize(file, data);//serializes the data into "gameInfo" file
        file.Close();//close file
    }//end saveData

    public void loadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))// if there is data to load
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);//opens requested file
            gameData data = (gameData)binFormatter.Deserialize(file); // Decrypts data
            file.Close();
            highScore = data.highScore;
        }//end if
    }//end load data
}

[Serializable]
class gameData {
    public int highScore;
}

