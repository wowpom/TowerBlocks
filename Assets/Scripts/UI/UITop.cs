using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITop : MonoBehaviour
{
    private bool binding = false;
    private Text level;
    private Text score;
    private Slider slider;

    private void Start()
    {
        
        level = GameObject.Find("Level").GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        
    }
    public void SetScore(int newScore)
    {
        score.text = newScore.ToString(); 
    }
    public void UpScore(int oldScore)
    {
        score.text = oldScore++.ToString();
    }

    public void SetLevel(int newLevel)
    {
        level.text ="Level " + newLevel.ToString();
    }
    public void UpLevel(int oldLevel)
    {
        level.text = "Level " + oldLevel++.ToString();
    }

    public void UpValueSlider()
    {
        slider.value++;
    }
    public void SetValueSlider(int newValue)
    {
        slider.value = newValue;
    }
    public void SetMaxValueSlider(int newValue)
    {
        slider.maxValue = newValue;
    }
    public void PressedButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if(binding == false)
        {
            if(UIManager.Instance != null)
            {
                UIManager.Instance.AddElement(gameObject.GetComponent<UIElement>());
                GameManager.Instance.InitializationUITop(gameObject);
                binding = true;
            }
        }
    }


}
