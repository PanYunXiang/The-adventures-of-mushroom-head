using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSaw : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            Transform t = transform.Find("Saw");
            if (t != null)
            {
                t.gameObject.SetActive(true);
                if (transform.name == "SawAchievement")
                {
                    PlayerController._instance.ChangeState(PlayerState.Die);
                    SaveFileMgr.Instance.AddAchievement("防不胜防");
                    //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_14);
                }
            }

            PlayerController._instance.ChangeState(PlayerState.Die);
        }
    }
}
