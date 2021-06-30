using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public Text bestScore;
    public InputField playerName;
    public Button startButton;

    public static Score best;
    public static Score score;

    private void Awake()
    {
        if (best == null)
        {
            best = new Score();
            best.Load();
        }
        score = new Score();

        bestScore.text = "Best: " + best.name + ":" + best.value;
    }

    public void StartGame()
    {
        score.name = playerName.text;
        score.value = 0;
        SceneManager.LoadScene(1);
    }

    public void InputFieldChanged()
    {
        startButton.interactable = playerName.text.Length > 0;
    }
}
