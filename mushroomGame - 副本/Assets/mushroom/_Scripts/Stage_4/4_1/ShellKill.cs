using UnityEngine;
class ShellKill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            PlayerController._instance.ChangeState(PlayerState.Die);
            GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

