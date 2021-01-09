using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDialog : UIElement
{
    public TypeDialog typeDialog;
    public enum TypeDialog
    {
        Exit,
        GameOver
    }
    public void SetTypeDialog(TypeDialog _typeDialog)
    {
        typeDialog = _typeDialog;
    }
    public override void Hide()
    {
        base.Hide();
    }
    public override void Show()
    {
        base.Show();
    }
    public void PressedNo()
    {
        if (typeDialog == TypeDialog.Exit) UIManager.Instance.ShowElement("Menu");
        else if (typeDialog == TypeDialog.GameOver) SceneManager.LoadScene(0);
        Hide();
    }
    public void PressedYes()
    {
        if (typeDialog == TypeDialog.Exit) Application.Quit();
        else if (typeDialog == TypeDialog.GameOver) SceneManager.LoadScene(1);
        Hide();
    }
}
