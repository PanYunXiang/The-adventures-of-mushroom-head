using UnityEngine;

class TrueFlagSwtich : MonoBehaviour
{
    public GameObject trueFlag;
    [HideInInspector]
    public bool bShowTrueFlag = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            if (bShowTrueFlag)
                trueFlag.SetActive(true);
        }
    }
}
