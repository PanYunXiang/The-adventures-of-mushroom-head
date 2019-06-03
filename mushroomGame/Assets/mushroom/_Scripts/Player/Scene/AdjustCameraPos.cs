using UnityEngine;
using DG.Tweening;

public class AdjustCameraPos : MonoBehaviour
{
    public bool bFollowPlayer = true;
    public Transform cameraTrans;
    [SerializeField]
    private Vector3 offsetPos;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            cameraTrans.DOMove(offsetPos, 1f);
            if (!bFollowPlayer)
            {
                cameraTrans.GetComponent<CameraMove>().bFollow = false;
            }
        }
    }
}
