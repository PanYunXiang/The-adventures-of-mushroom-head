using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject player;
    /// <summary>
    /// 飞机是否移动
    /// 当玩家没有碰到飞机，飞机不能移动
    /// 当玩家碰到飞机，开始自动移动
    /// 点击屏幕飞机向上飞
    /// </summary>
    private bool bMove = false;

    private Rigidbody2D rigid;
    private Vector2 power;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        power = new Vector2(0, 3f);
    }

    void Update()
    {
        if (bMove)
        {
            transform.position += transform.right * 1.5f * Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
            {
                rigid.velocity = power;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            player.SetActive(false);
            bMove = true;
            PlayerController._instance.ChangeState(PlayerState.Idle);
        }

        if (coll.collider.name == "Fall")
        {
            gameObject.SetActive(false);
            player.transform.position = transform.position;
            bMove = false;
            player.SetActive(true);
            PlayerController._instance.ChangeState(PlayerState.Idle);
        }
        if (coll.collider.name.StartsWith("Pipe"))
        {
            bMove = false;
            Debug.Log("Gameover");
            LevelMgr.DieCount++;
            LevelMgr._instacne.ShowLosePanel(LevelMgr.DieCount++);
            SaveFileMgr.PlayerInfo.dieCount++;
            SaveFileMgr.Instance.SaveFile();
        }
    }
}
