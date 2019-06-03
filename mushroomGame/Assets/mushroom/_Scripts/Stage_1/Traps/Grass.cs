using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Grass : MonoBehaviour
{
    public GameObject pac_man;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            pac_man.SetActive(true);
            pac_man.GetComponent<Pac_mam>().Move();
        }
    }
}
