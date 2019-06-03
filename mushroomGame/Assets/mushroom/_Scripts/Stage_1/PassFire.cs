using UnityEngine;

public class PassFire : MonoBehaviour
{
    public GameObject chosePanel;
    public GameObject flag;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Player")
        {
            chosePanel.SetActive(true);
            transform.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void Pass()
    {
        Debug.Log("传火");
        SaveFileMgr.Instance.AddAchievement("传火使我快乐");
        //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_3);
        chosePanel.SetActive(false);
        PlayerController._instance.ChangeState(PlayerState.Die);

    }
    public void NoPass()
    {
        Debug.Log("不传");
        SaveFileMgr.Instance.AddAchievement("这火我不传");
        //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_2);
        chosePanel.SetActive(false);
        flag.SetActive(true);
    }
}
