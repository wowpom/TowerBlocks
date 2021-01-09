using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Player Player;
    private void Start()
    {

    }

    /// <summary>
    /// Проверка на столкновение куба и платформы
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Player.Instance.isBlock = true;
    }
    
}
