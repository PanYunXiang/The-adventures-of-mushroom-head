using UnityEngine;

public class LeiMu : MonoBehaviour
{
    public GameObject[] texts;
    public GameObject chosePanel;
    public GameObject ladder;

    private void Start()
    {
        SetTextShow();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            SetTextShow(1);
            Invoke("ShowPanel", 1f);
        }
    }

    /// <summary>
    /// 显示某个text内容
    /// </summary>
    /// <param name="index">text的索引</param>
    void SetTextShow(int index = 0)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            if (i == index)
                texts[i].SetActive(true);
            else
                texts[i].SetActive(false);
        }
    }

    public void OnBtnAccept()
    {
        SetTextShow(3);
        Invoke("HideLeiMu", 2f);
        SaveFileMgr.Instance.AddAchievement("德国骨科");
        //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_8);
    }

    public void OnBtnRefuse()
    {
        SetTextShow(2);
        Invoke("HideLeiMu", 2f);
    }

    void HideLeiMu()
    {
        gameObject.SetActive(false);
        chosePanel.SetActive(false);
        ///出现上下移动的梯子
        ladder.SetActive(true);
    }

    void ShowPanel()
    {
        chosePanel.SetActive(true);
    }
}

