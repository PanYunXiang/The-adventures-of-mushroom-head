using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Geralt : MonoBehaviour
{
    public GameObject dialog;
    public SpriteRenderer matrial;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Fork")
        {
            dialog.SetActive(true);
            Invoke("HideDialog", 1.5f);
        }
    }

    void HideDialog()
    {
        transform.DOMoveY(0, 0.2f).OnPlay(
                () =>
                {
                    matrial.DOFade(0, 0.2f);
                }).OnComplete(
                () =>
                {
                    dialog.SetActive(false);
                    SaveFileMgr.Instance.AddAchievement("对猎魔人宝具");
                    //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_5);
                }
                );
    }

}
