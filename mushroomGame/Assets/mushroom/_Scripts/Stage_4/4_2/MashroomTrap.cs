using UnityEngine;
using DG.Tweening;

class MashroomTrap : MonoBehaviour
{
    [SerializeField]
    private Vector3 jumpPos;
    [SerializeField]
    private float endX;

    public void MashroomMove()
    {
        transform.DOJump(jumpPos, 0.5f, 1, 0.5f).SetEase(Ease.Linear).OnComplete(
            ()=>
            {
                transform.DOMoveX(endX, 1f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
            });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerController._instance.ChangeState(PlayerState.Die);
        }
    }
}
