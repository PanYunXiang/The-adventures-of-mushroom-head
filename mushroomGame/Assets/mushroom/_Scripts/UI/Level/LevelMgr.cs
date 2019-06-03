using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelMgr : MonoBehaviour
{
    public static LevelMgr _instacne;

    public GameObject losePanel;
    public GameObject winPanel;

    public Sprite[] loseSprits;
    public GameObject achievementPanel;
    public GameObject btnMove_L;
    public GameObject btnMove_R;
    public GameObject btnJump;
    public GameObject musicTip;
    /// <summary>
    /// 记录玩家当前关卡死亡的次数
    /// 再加载的时候重置为0
    /// </summary>
    public static int DieCount { set; get; }

    #region Unity事件
    void Awake()
    {
        _instacne = this;
    }

    void Start()
    {
        //绑定按钮事件
        if (btnMove_L != null && btnMove_R != null && btnJump != null)
        {
            MyEventTriger.GetEvent(btnMove_R).onDown += OnBtnDown;
            MyEventTriger.GetEvent(btnMove_R).onUp += OnBtnUp;
            MyEventTriger.GetEvent(btnJump).onDown += OnBtnDown;
            MyEventTriger.GetEvent(btnMove_L).onDown += OnBtnDown;
            MyEventTriger.GetEvent(btnMove_L).onUp += OnBtnUp;
        }
    }

    void Update()
    {
        ////测试
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    ShowLosePanel(6);
        //}
    }

    void OnDestroy()
    {
        if (btnMove_L != null && btnMove_R != null && btnJump != null)
        {
            MyEventTriger.GetEvent(btnMove_R).onDown -= OnBtnDown;
            MyEventTriger.GetEvent(btnMove_R).onUp -= OnBtnUp;
            MyEventTriger.GetEvent(btnJump).onDown -= OnBtnDown;
            MyEventTriger.GetEvent(btnMove_L).onDown -= OnBtnDown;
            MyEventTriger.GetEvent(btnMove_L).onUp -= OnBtnUp;
        }
    }
    #endregion

    #region 按钮事件处理
    /// <summary>
    /// 返回开始界面
    /// </summary>
    public void BtnReturn()
    {
        Debug.Log("返回开始界面");
        ScenesMgr.Instance.LoadScene(VariablePath.StartScene);
    }

    /// <summary>
    /// 重新本关卡
    /// </summary>
    public void BtnRestart()
    {
/*        Debug.Log("重新本关卡");*/
        AudioMgr._instance.PlayFx("Btn");
        ScenesMgr.Instance.ResetLevel();
    }

    /// <summary>
    /// 下一个关卡
    /// </summary>
    public void BtnNextLevel()
    {
        ScenesMgr.Instance.LoadScene(VariablePath.LoadScene);
        AudioMgr._instance.PlayFx("Btn");
    }

    /// <summary>
    /// 背景音乐开关
    /// </summary>
    bool bOn = true;
    public void BtnSwtichBGM()
    {
        Debug.Log("背景音乐开关");
        AudioMgr._instance.PlayFx("Btn");
        bOn = !bOn;
        if (!bOn)
        {
            musicTip.SetActive(false);
            AudioMgr._instance.OffBgm();
        }
        else
        {
            musicTip.SetActive(true);
            AudioMgr._instance.PlayCurrentBgm();
        }
    }

    public void BtnJump()
    {
        PlayerController._instance.ChangeState(PlayerState.Jump);
    }

    #region 处理按钮长按事件
    void OnBtnDown(GameObject go)
    {
        if (go.name == "BtnMove_R")
        {
            if (PlayerController._instance != null)
            {
                PlayerController._instance.ChangeState(PlayerState.Run);
                PlayerController._instance.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
            }
            if (Plane._instance != null)
            {
                Plane._instance.ChangeState(Plane.PlaneState.Right);
            }
        }
        else if (go.name == "BtnMove_L")
        {
            if (PlayerController._instance != null)
            {
                PlayerController._instance.ChangeState(PlayerState.Run);
                PlayerController._instance.transform.localScale = new Vector3(-0.8f, 0.8f, 1f);
            }

            if (Plane._instance != null)
            {
                Plane._instance.ChangeState(Plane.PlaneState.Left);
            }
        }
        else if (go.name == "BtnJump")
        {
            if (PlayerController._instance != null)
            {
                PlayerController._instance.ChangeState(PlayerState.Jump);
            }
            if (Plane._instance != null)
            {
                Plane._instance.Fire();
            }
        }
    }
    void OnBtnUp(GameObject go)
    {
        if (go.name == "BtnMove_R" || go.name == "BtnMove_L")
        {
            if (PlayerController._instance != null)
            {
                PlayerController._instance.ChangeState(PlayerState.Idle);
            }
            if (Plane._instance != null)
            {
                Plane._instance.ChangeState(Plane.PlaneState.Idle);
            }
        }
    }
    #endregion
    #endregion

    #region UI显示相关
    /// <summary>
    /// 根据死亡次数，显示不同的losePanel
    /// 主要是图片的显示
    /// </summary>
    /// <param name="loseCount">死亡次数</param>
    public void ShowLosePanel(int loseCount)
    {
        Debug.Log("显示LosePanel");
        if (losePanel != null)
        {
            if (loseCount < 1) return;
            losePanel.SetActive(true);
            Image img = losePanel.transform.Find("Image").GetComponent<Image>();
            if (loseCount < 2)
            {
                img.sprite = loseSprits[0];
            }
            else if (loseCount < 4)
            {
                img.sprite = loseSprits[1];
            }
            else
            {
                img.sprite = loseSprits[2];
            }
        }
    }
    public void ShowWinPanel()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
    }

    /// <summary>
    /// 显示成就界面
    /// </summary>
    /// <param name="achievementName">获得的成就名字</param>
    public void ShowAchievement(string achievementName)
    {
        Debug.Log("显示AchievementPanel");
        AudioMgr._instance.PlayFx("Tip");

        Transform tChild = achievementPanel.transform.Find("Text");
        tChild.GetComponent<Text>().text = achievementName;

        RectTransform rt = achievementPanel.GetComponent<RectTransform>();
        DOTween.To(() => { return rt.anchoredPosition; }, v => { rt.anchoredPosition = v; }, new Vector2(0, -80f), 0.3f)
            .OnComplete(
            () =>
            {
                Invoke("ResetAchievementPanel", 2f);
                if (SaveFileMgr.PlayerInfo.achievents.Count == GameModels.GetAchievement("Achievement").Achievement.Count - 1)
                {
                    Invoke("AddLastAchievement", 2f);
                }
            });
    }
    void ResetAchievementPanel()
    {
        RectTransform rt = achievementPanel.GetComponent<RectTransform>();
        DOTween.To(() => { return rt.anchoredPosition; }, v => { rt.anchoredPosition = v; }, new Vector2(0, 80f), 0.3f);
    }
    #endregion

    void AddLastAchievement()
    {
        ShowAchievement(string.Format("宅王--{0}", SaveFileMgr.PlayerInfo.playerName));
        SaveFileMgr.PlayerInfo.achievents.Add(string.Format("宅王--{0}", SaveFileMgr.PlayerInfo.playerName));
        SaveFileMgr.PlayerInfo.time.Add(System.DateTime.Now.ToString("yyyy-MM-dd"));
        SaveFileMgr.Instance.SaveFile();
    }
}
