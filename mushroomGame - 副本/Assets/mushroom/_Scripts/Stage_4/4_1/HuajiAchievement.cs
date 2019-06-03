using UnityEngine;
class HuajiAchievement :  MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            SaveFileMgr.Instance.AddAchievement("万事大稽");
            //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_16);
        }
    }
}
