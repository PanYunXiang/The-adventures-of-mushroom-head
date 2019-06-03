using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBourn : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            PlayerController._instance.ChangeState(PlayerState.Die);
        }
    }
}
