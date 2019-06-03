using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HuajiDan : MonoBehaviour
{
    private float dropPoxX;
    private Ease animType;
    private Vector3 oldPos;


    void Start()
    {
        oldPos = transform.position;

        transform.DOLocalMove(new Vector3(dropPoxX, -11f, 0), 5f).SetEase(animType);
        StartCoroutine(LoopAnim());
    }

    IEnumerator LoopAnim()
    {
        while (true)
        {
            dropPoxX = Random.Range(-7.4f, 6f);
            animType = (Ease)Random.Range(0, 32);
            transform.DOLocalMove(new Vector3(dropPoxX, -11f, 0), 5f).SetEase(animType).OnComplete(
                () =>
                {
                    transform.position = oldPos;
                });

            yield return new WaitForSeconds(5.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerController._instance.ChangeState(PlayerState.Die);
        }
    }
}
