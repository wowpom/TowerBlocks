using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : UIElement
{
    bool binding = false;

    private Slider slider;

    public void Start()
    {
        
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        
    }
    public override void Hide()
    {
        base.Hide();
    }
    public override void Show()
    {
        base.Show();
    }
    public void AudioVolume()
    {
        float sliderValue = slider.value;
        GameReferens.Instance.ChangeVolume(sliderValue);
    }
    public void PressedMenu()
    {
        UIManager.Instance.ShowElement("Menu");
        Hide();
    }
    private void Update()
    {
        if(binding == false)
        {
            if(UIManager.Instance != null)
            {
                UIManager.Instance.AddElement(gameObject.GetComponent<UIElement>());
                binding = true;
                Hide();
            }
        }
    }
}
