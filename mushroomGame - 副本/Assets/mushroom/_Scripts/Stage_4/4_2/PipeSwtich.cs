using UnityEngine;

class PipeSwtich : MonoBehaviour
{
    public GameObject shell;

    private int hitCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            hitCount++;
            if (hitCount == 3)
            {
                shell.SetActive(true);
            }
        }
    }
}
