using UnityEngine;
using DG.Tweening;

public class DownTrap : MonoBehaviour
{
    [Tooltip("下落的位置")]
    public Vector3 downPos;
    public GameObject trap;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            transform.DOMove(downPos, 1f);
            trap.SetActive(true);
        }
    }
}
