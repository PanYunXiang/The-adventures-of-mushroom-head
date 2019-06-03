using UnityEngine;
using DG.Tweening;

public class MoveBullet : MonoBehaviour
{
    [Tooltip("移动开始的初始位置")]
    public Vector3 startMovePos;
    public Pitch_Fork fork;

    /// <summary>
    /// 是否可以攻击玩家
    /// </summary>
    private bool bKillPlayer = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            fork.bPickUp = false;

            transform.DORotate(new Vector3(0, 0, 360f), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
            if (!bKillPlayer)
            {
                transform.position = startMovePos;
                transform.DOMoveX(8f, 4f).SetEase(Ease.Linear);
            }
            if (bKillPlayer)
            {
                PlayerController._instance.ChangeState(PlayerState.Die);
                gameObject.SetActive(false);
            }
        }
        if (coll.name == "Geralt")
        {
            transform.DOMoveX(-15f, 4).SetEase(Ease.Linear);
            bKillPlayer = true;
        }
        if (coll.name == "Bound")
        {
            transform.DOMoveX(8f, 4f).SetEase(Ease.Linear);
        }
    }
}
