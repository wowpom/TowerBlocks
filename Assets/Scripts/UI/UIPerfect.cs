using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPerfect : UIElement
{
    private bool binding = false;
    private AudioSource audioGreat;
    private void Start()
    {
        
        audioGreat = gameObject.GetComponent<AudioSource>();
        
        
    }
    public void StartCoroutinePerfect()
    {
        Show();
        StartCoroutine(PerfectText());
    }
    public IEnumerator PerfectText()
    {
        audioGreat.Play();
        yield return new WaitForSeconds(0.8f);
        Hide();
    }
    private void Update()
    {
        if(binding == false)
        {
            if(UIManager.Instance != null)
            {
                GameManager.Instance.InitializationUIperfect(gameObject);
                UIManager.Instance.AddElement(gameObject.GetComponent<UIElement>());
                binding = true;
                Hide();
            }
        }
    }
}
