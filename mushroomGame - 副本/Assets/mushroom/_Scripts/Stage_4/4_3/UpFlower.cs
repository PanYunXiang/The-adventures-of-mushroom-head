using UnityEngine;
class UpFlower : MonoBehaviour
{
    public TrueFlagSwtich showFlag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerController._instance.ChangeState(PlayerState.Die);
            if (showFlag != null && transform.name == "FakeFlag")
            {
                showFlag.bShowTrueFlag = false;
            }
        }
    }
}

