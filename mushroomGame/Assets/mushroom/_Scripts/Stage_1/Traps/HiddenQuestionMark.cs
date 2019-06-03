 using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HiddenQuestionMark : MonoBehaviour
{
    public Transform questionMark;
    public Transform huajiCoin;
    public Transform mashroom;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            questionMark.parent.gameObject.SetActive(true);
            //questionMark.gameObject.SetActive(true);
            HuajiCoinAnim();
            MashroomAnim();
        }
    }

    void HuajiCoinAnim()
    {
        if (huajiCoin != null)
        {
            AudioMgr._instance.PlayFx("Coin");
            huajiCoin.DOLocalMoveY(0.5f, 0.5f).OnComplete(
                () =>
                {
                    questionMark.gameObject.SetActive(false);
                    /*huajiCoin.gameObject.SetActive(false);*/
                    /* SaveFileMgr.PlayerInfo.huaJiCoin++;*/
                    Destroy(huajiCoin.gameObject);
                });
        }
    }

    void MashroomAnim()
    {
        if (mashroom != null)
        {
            mashroom.DOLocalJump(new Vector3(0, 0.46f, 0), 0.3f, 1, 1f);
            questionMark.gameObject.SetActive(false);
        }
    }
}