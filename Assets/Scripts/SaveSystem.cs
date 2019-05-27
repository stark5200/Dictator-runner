using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData playerData = new PlayerData(player);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return playerData;

        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveHighscore(ScoreManager scoreManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscore.xml";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData scoreData = new ScoreData(scoreManager);
        formatter.Serialize(stream, scoreData);
        stream.Close();
    }


    public static ScoreData LoadHighscore()
    {
        string path = Application.persistentDataPath + "/highscore.xml";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData scoreData = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return scoreData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
