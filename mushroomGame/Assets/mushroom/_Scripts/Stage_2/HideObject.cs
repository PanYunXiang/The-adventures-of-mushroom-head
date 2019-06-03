using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public GameObject[] hideObjects;
    public GameObject[] youDied;
    public GameObject shell;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            ShowObjects();
            PlayerController._instance.ChangeState(PlayerState.Idle);
            if (shell != null)
            {
                ShowShell();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            ShowYouDied();
        }
    }

    void ShowObjects()
    {
        if (hideObjects.Length > 0)
        {
            for (int i = 0; i < hideObjects.Length; i++)
            {
                hideObjects[i].SetActive(true);
            }
        }
    }

    /// <summary>
    /// 显示YOUDIED
    /// </summary>
    void ShowYouDied()
    {
        if (youDied.Length > 0)
        {
            for (int i = 0; i < youDied.Length; i++)
            {
                youDied[i].SetActive(true);
            }
        }
    }

    /// <summary>
    /// 显示炮弹
    /// </summary>
    void ShowShell()
    {
        if (shell != null)
        {
            shell.SetActive(true);
        }
    }
}
