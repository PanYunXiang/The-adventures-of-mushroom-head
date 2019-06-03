using UnityEngine;
using DG.Tweening;

class Bullet : MonoBehaviour
{

    public void Fly()
    {
        transform.DOLocalMoveY(9f, 1f).SetEase(Ease.Linear).OnComplete(() => { Destroy(gameObject); });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.StartsWith("HuajiDan"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Plane._instance.HuajiCount++;
            if (Plane._instance.HuajiCount == 24)
            {
                Plane._instance.SetLightingVisable();
                SaveFileMgr.Instance.AddAchievement("天下大稽");
                //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_13);
                Plane._instance.ChangeState(Plane.PlaneState.Die);
            }
        }
        if (collision.collider.name == "HuaJi")
            Destroy(collision.gameObject);
    }
}

