using UnityEngine;

class SwitchProgress : MonoBehaviour
{
    public GameObject propressUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (LevelMgr.DieCount >= 1)
                propressUI.SetActive(true);
        }
    }
}
