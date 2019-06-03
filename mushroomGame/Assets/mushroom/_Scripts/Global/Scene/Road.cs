using UnityEngine;
using DG.Tweening;

public class Road : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        ///当玩家吃到的蘑菇个数达到一定个数，地面下陷
        ///1-4使用
        if (MashroomCount._instacne != null)
        {
            if (MashroomCount._instacne.Count >= 5)
            {
                transform.DOMoveY(-5f, 1).OnComplete(
                    ()=>
                    {
                        SaveFileMgr.Instance.AddAchievement("该减肥了");
                        //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_10, null);
                    });
            }
        }
        PlayerController._instance.ChangeState(PlayerState.Idle);
        PlayerController._instance.BJump = true;
    }
}
