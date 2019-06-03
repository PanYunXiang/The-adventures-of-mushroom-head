using UnityEngine;

class Lightning : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerController._instance.ChangeState(PlayerState.Die);
        }
    }
}
