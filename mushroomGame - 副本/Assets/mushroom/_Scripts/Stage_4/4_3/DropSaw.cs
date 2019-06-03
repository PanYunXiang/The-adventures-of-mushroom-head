using UnityEngine;
using DG.Tweening;

class DropSaw : MonoBehaviour
{
    public float endY;

    public void Drop()
    {
        transform.DOMoveY(endY, 0.5f).SetEase(Ease.Linear).OnComplete(
            ()=>
            {
                gameObject.SetActive(false);
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
