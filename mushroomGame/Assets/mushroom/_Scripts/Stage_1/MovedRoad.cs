using UnityEngine;
using DG.Tweening;

public class MovedRoad : MonoBehaviour
{
    [Tooltip("结束移动的位置")]
    public Vector3 endPos;
    [Tooltip("移动需要的时间")]
    public float time;
    public GameObject saw;

    bool bShowSaw = false;

    void Start()
    {
        transform.DOMove(endPos, time).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        if (saw != null && bShowSaw && transform.position.x > 3.5f)
        {
            saw.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            bShowSaw = true;
        }
    }
}
