using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mashroom : MonoBehaviour
{
    /// <summary>
    /// 3-1触发滑稽蛋
    /// </summary>
    public GameObject huaji;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (transform.name == "PoisonMashroom")
            {
                PlayerController._instance.ChangeState(PlayerState.Die);
            }
            if (transform.name != "PoisonMashroom" && MashroomCount._instacne != null)
            {
                ///成就“该减肥了”
                transform.gameObject.SetActive(false);
                MashroomCount._instacne.Count++;
            }
            if (transform.name == "Shell")
            {
                PlayerController._instance.ChangeState(PlayerState.Die);
            }
            ///成就“TAN 90”
            if (transform.name == "MushroomAchievement")
            {
                SaveFileMgr.Instance.AddAchievement("TAN 90");
                //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_tan_90);
                gameObject.SetActive(false);
            }
            if (transform.name == "FakeFlag")
            {
                if (huaji != null)
                    huaji.SetActive(true);
                else
                    PlayerController._instance.ChangeState(PlayerState.Die);
            }
        }
    }
}