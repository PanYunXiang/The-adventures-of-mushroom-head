using UnityEngine;
using DG.Tweening;

public class BanBen_R : MonoBehaviour
{
    public static bool bCount = false;//开始不计数
    public GameObject banBen;

    private void Start()
    {
        bCount = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            BanBen_L.bCount = true;
            if (bCount)
            {
                bCount = false;
                BanBen.secretCount++;
                Debug.Log(BanBen.secretCount);
            }
            if (BanBen.secretCount == 5)
            {
                SaveFileMgr.Instance.AddAchievement("秘籍：反复横跳");
                //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_15);
                banBen.transform.DOMoveY(2.5f, 1.5f).OnComplete(
                    () =>
                    {
                        banBen.SetActive(false);
                    });
            }
        }
    }
}
