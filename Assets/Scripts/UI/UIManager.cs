using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance => instance;

    //Список всех UIElement на сцене
    private List<UIElement> uiElement = new List<UIElement>();

    void Start()
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
    public void AddElement(UIElement uIElement)
    {
        uiElement.Add(uIElement);
    }
    public UIElement GetElement(string name)
    {
        
        foreach (var element in uiElement)
        {
            if (element.name == name) return element;
        }
        return null;
    }
    public void ShowElement(string name) 
    {
        foreach(var element in uiElement)
        {
            if (element.name == name) element.Show();
            
        }

    }
    public void HideElement(string name)
    {
        foreach (var element in uiElement)
        {
            if (element.name == name) element.Hide();
        }
    }

}
