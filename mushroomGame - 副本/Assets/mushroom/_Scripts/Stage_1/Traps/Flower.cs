using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject[] saws;
    public GameObject[] youDied;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            gameObject.SetActive(false);
            ShowSaws();
            ShowYouDied();
        }
    }

    void ShowSaws()
    {
        if (saws.Length > 0)
        {
            for (int i = 0; i < saws.Length; i++)
            {
                saws[i].SetActive(true);
            }
        }
    }

    void ShowYouDied()
    {
        if (youDied.Length > 0)
        {
            for (int i = 0; i < youDied.Length; i++)
            {
                youDied[i].SetActive(true);
            }
        }
    }
}
