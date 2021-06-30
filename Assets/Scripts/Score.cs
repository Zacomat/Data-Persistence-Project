using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class Score
{
    public String name;
    public int value;

    public Score() { }

    public Score(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/score.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            String json = File.ReadAllText(path);
            Debug.Log("Load score: json=" + json);
            Score score = JsonUtility.FromJson<Score>(json);
            name = score.name;
            value = score.value;
        }
        else
        {
            Debug.Log("Load score: File not found: " + path);
        }
    }

    public void Save()
    {
        String json = JsonUtility.ToJson(this);
        Debug.Log("Save score: json=" + json);
        String path = Application.persistentDataPath + "/score.json";
        Debug.Log(path);
        File.WriteAllText(path, json);
    }

}
