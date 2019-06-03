using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    /// <summary>
    /// Camera是否跟随玩家
    /// 默认是跟随的
    /// </summary>
    [HideInInspector]
    public bool bFollow = true;

    [SerializeField]
    private float startMoveX;
    [SerializeField]
    private float endMoveX;
    [SerializeField]
    private Vector3 endFixedPos;

    bool bMoveY = true;

    void Update()
    {
        if (bFollow)
            FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player.transform.position.x > endMoveX) return;

        if (player.transform.position.x > startMoveX)
        {
            Vector3 a = transform.position;
            Vector3 b = player.transform.position;
            transform.position = new Vector3(b.x, a.y, a.z);
        }
    }
}
