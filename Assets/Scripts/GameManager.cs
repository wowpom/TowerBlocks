using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;
    public static GameManager Instance => instance;

    private UITop uiTop;
    private UIPerfect uiPerfect;

    public int Score;
    public int Level;
    public int ScoreForUpLevel;
    
    public int Swinging;
    public bool isGameOver = false;

    [Header("Максимальное раскачивание здания")]
    [Header("Настройка сложности игры")]
    public int SwingingMax;
    [Header("Скорость раскачивания блока над платформой")]
    [Range(0, 1)]
    public float SpeedSwing;



    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }



    /// <summary>
    /// Инициализация UITop 
    /// </summary>
    /// <param name="gameObject"></param>
    

    public void InitializationUITop(GameObject gameObject)
    {
        uiTop = gameObject.GetComponent<UITop>();
        if (GameReferens.Instance.gameType == GameReferens.GameType.Challenge)
        {
            Level = 1;
            ScoreForUpLevel = Level * 10;
        }
        else
        {
            Level = GameReferens.Instance.level;
            ScoreForUpLevel = Level * 10;

            uiTop.SetLevel(GameReferens.Instance.level);
            uiTop.SetScore(GameReferens.Instance.score);
        }

        uiTop.SetMaxValueSlider(ScoreForUpLevel);
    }
    /// <summary>
    /// Инициализация UIPerfect
    /// </summary>
    /// <param name="gameObject"></param>


    public void InitializationUIperfect(GameObject gameObject)
    {
        uiPerfect = gameObject.GetComponent<UIPerfect>(); 
    }


    /// <summary>
    /// Изменения очков
    /// </summary>
    public void ChangeScore()
    {
        Score++;
        uiTop.SetScore(Score);
        uiTop.UpValueSlider();
        if (ScoreForUpLevel == Score)
        {
            Level++;
            ScoreForUpLevel =ScoreForUpLevel + Level * 10;
            ChangeLevel();
            uiTop.SetMaxValueSlider(ScoreForUpLevel);
            uiTop.SetValueSlider(0);

        }
        else if (ScoreForUpLevel - 1 == Score && GameReferens.Instance.gameType == GameReferens.GameType.Default) 
            Player.Instance.isLastBlock = true;
    }


    /// <summary>
    /// Изменение уровня
    /// </summary>
    public void ChangeLevel()
    {
        if (GameReferens.Instance.gameType == GameReferens.GameType.Default)
        {
            GameReferens.Instance.UpLevel();
        }
        uiTop.SetLevel(Level);
        Player.Instance.ChangeCube();
    }

    /// <summary>
    /// вызов текста при идельной установке блока
    /// </summary>
    public void GreatText()
    {

        uiPerfect.StartCoroutinePerfect();

    }

    /// <summary>
    /// Вызов окна при проигрыше
    /// </summary>
    public void GameOver()
    {
        Destroy(Player.Instance.Platform);
        Destroy(Player.Instance.GameBlock);
        isGameOver = true;
        GameReferens.Instance.onDialog("Game over! Restart game?", UIDialog.TypeDialog.GameOver);
    }
}
