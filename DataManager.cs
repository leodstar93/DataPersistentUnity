using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string newName;
    public int score;
    public int oldScore;
    // Start is called before the first frame update
    [System.Serializable]
    class SaveData
    {
        public string topName;
        public int topScore;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.topName = newName;
        data.topScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
       
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.topName;
            score = data.topScore;
            oldScore = data.topScore;
        }
    }

    public void SetName(string name)
    {
        newName = name;
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SetScore(int m_Points)
    {
            score =  m_Points;
    }
}
