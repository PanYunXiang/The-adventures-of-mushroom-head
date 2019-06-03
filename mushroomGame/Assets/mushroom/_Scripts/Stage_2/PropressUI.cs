using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PropressUI : MonoBehaviour
{
    public GameObject[] flags;//0为假，1为真
    public GameObject propressUI;
    public GameObject running;
    public Text[] texts;//1为成就程序，0位普通程序

    private bool bShowAchievement;

    private void Start()
    {
        bShowAchievement = false;
        InitText();
    }

    /// <summary>
    /// 初始化两个按钮中的内容
    /// </summary>
    void InitText()
    {
        texts[0].text = string.Format("girl.Name = \"波多野结衣\";\r\n" +
            "girl.Height = 163;\r\n" +
            "girl.Weight = 51.5f;\r\n" +
            "girl.BWH = \"88E,99,85\";\r\n" +
            "girl.GetBoyFried({0}); ", SaveFileMgr.PlayerInfo.playerName);
        texts[1].text = string.Format("girl.Name = \"新垣結衣\";\r\n" +
            "girl.Height = 169;\r\n" +
            "girl.Weight = 48.1f;\r\n" +
            "girl.BWH = \"32B,24,34\"\r\n" +
            "girl.GetBoyFried({0});", SaveFileMgr.PlayerInfo.playerName);
    }

    public void OnBtn0Click()
    {
        bShowAchievement = false;
        SetRunning();
    }

    public void OnBtn1Click()
    {
        bShowAchievement = true;
        SetRunning();
    }

    void SetRunning()
    {
        propressUI.SetActive(false);
        running.SetActive(true);
        Text t = running.GetComponent<Text>();
        t.DOText("程序运行中...", 1f).SetLoops(3, LoopType.Restart).OnComplete(
            ()=> 
            {
                if (bShowAchievement)
                {
                    SaveFileMgr.Instance.AddAchievement("object is null");
                    //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_object_is_null);
                }
                t.text = "关卡已解锁";
                Invoke("HideThis", 2f);
            });
    }

    void HideThis()
    {
        gameObject.SetActive(false);
        flags[0].SetActive(false);
        flags[1].SetActive(true);
    }
}
