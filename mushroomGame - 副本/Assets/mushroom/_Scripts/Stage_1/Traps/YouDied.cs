using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDied : MonoBehaviour
{
    /// <summary>
    /// 是否计数
    /// 显示陷阱
    /// </summary>
    public bool bCount = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            if (bCount)
            {
                ShowMashroom._instance.Count++;
                bCount = false;
            }
        }

    }
}
