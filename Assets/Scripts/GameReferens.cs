using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameReferens : MonoBehaviour
{
    private static GameReferens instance = null;
    public static GameReferens Instance => instance;
    public AudioMixer Am;
    private GameObject dialog;
    private Text textDialog;
    public int level { get; private set; }
    public int score { get; private set; }

    public Action<string, UIDialog.TypeDialog> onDialog { get; private set; }

    public GameType gameType { get; private set; }
    public enum GameType
    {
        Default,
        Challenge
    }
    void Start()
    {
        if (instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManager();
            onDialog += ShowDialog;
            dialog = GameObject.Find("Dialog");
            textDialog = GameObject.Find("DialogText").GetComponent<Text>();
            dialog.SetActive(false);
        }
        else
        { 
            Destroy(gameObject); 
        }

        
    }
    
    public void ChangeGameType(GameType newGameType)
    {
        gameType = newGameType;
    }
    public void ChangeLevel(int newLevel)
    {
        level = newLevel;
    }
    public void UpLevel()
    {
        level++;
    }
    public void ChangeScore(int newScore)
    {
        score = newScore;
    }
    public void UpScore()
    {
        score++;
    }


    private void InitializeManager()
    {
        level = 1;
        score = 0;
    }
    
    public void ShowDialog(string text, UIDialog.TypeDialog typeDialog)
    {
        textDialog.text = text;
        dialog.GetComponent<UIDialog>().SetTypeDialog(typeDialog);
        dialog.SetActive(true);
    }

    public void ChangeVolume(float sliderValue)
    {
        Am.SetFloat("MasterVolume", sliderValue);
    }

}
