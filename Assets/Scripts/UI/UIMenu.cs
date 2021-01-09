using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIMenu : UIElement
{
    private GameObject restartGame;
    bool binding = false;
    
    public void Start()
    {
        
        restartGame = GameObject.Find("ButtonRestart");
        
        
    }
    public override void Hide()
    {
        base.Hide();
    }
    public override void Show()
    {
        base.Show();
    }
    public void StartGame()
    {
        GameReferens.Instance.ChangeGameType(GameReferens.GameType.Default);
        SceneManager.LoadScene(1);
    }
    public void StartChallenge()
    {
        GameReferens.Instance.ChangeGameType(GameReferens.GameType.Challenge);
        SceneManager.LoadScene(1);
    }
    public void PressedSetting()
    {
        UIManager.Instance.ShowElement("Settings");
        Hide();
    }
    public void PressedExit()
    {
        GameReferens.Instance.onDialog?.Invoke("Bye?", UIDialog.TypeDialog.Exit);
        Hide();
    }
    

    public void RestartGame()
    {
        GameReferens.Instance.ChangeLevel(1);
        StartGame();
    }
    private void Update()
    {
        if(binding == false)
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.AddElement(gameObject.GetComponent<UIElement>());
                binding = true;
                if (GameReferens.Instance.level == 1) restartGame.SetActive(false);
            }
        }
        
        
    }
}
