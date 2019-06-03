using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanBen_L : MonoBehaviour
{
    private void Start()
    {
        bCount = false;
    }
    public static bool bCount = false;//开始不计数
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            BanBen_R.bCount = true;
            if (bCount)
            {
                bCount = false;
                BanBen.secretCount++;
                Debug.Log(BanBen.secretCount);
                BanBen_R.bCount = true;
            }
        }
    }
}
