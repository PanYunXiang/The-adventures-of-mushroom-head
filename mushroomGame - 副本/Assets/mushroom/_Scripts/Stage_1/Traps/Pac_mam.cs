using UnityEngine;
using DG.Tweening;

public class Pac_mam : MonoBehaviour
{
    [SerializeField]
    private float endX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlayerController._instance.ChangeState(PlayerState.Die);
        }
    }

    public void Move()
    {
        transform.DOLocalMoveX(-3f, 0.5f);
    }
}
