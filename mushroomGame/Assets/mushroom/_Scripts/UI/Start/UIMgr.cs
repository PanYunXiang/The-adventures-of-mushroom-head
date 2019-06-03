using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

class UIMgr : MonoBehaviour
{
    public GameObject achievement;
    public GameObject levelSelect;
    public GameObject aboutGame;
    public GameObject inputName;

    /// <summary>
    /// 开始按钮事件
    /// </summary>
    public void OnBtnStartClick()
    {
        Debug.Log("显示关卡选择界面");
        AudioMgr._instance.PlayFx("Btn");
        if (SaveFileMgr.PlayerInfo.bNameExist)//如果玩家名字存在，则弹出关卡选择界面
        {
            RectTransform rt = levelSelect.GetComponent<RectTransform>();
            DOTween.To(
                () =>
                {
                    return rt.anchoredPosition;
                },
                    v => { rt.anchoredPosition = v; }, new Vector2(0, 0f), 0.3f);
        }
        ///如果玩家名字不存在，则弹出输入姓名界面
        else
        {
            inputName.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 成就按钮事件
    /// </summary>
    public void OnBtnAchievementClick()
    {
        Debug.Log("显示成就界面");
        AudioMgr._instance.PlayFx("Btn");
        RectTransform rt = achievement.GetComponent<RectTransform>();
        DOTween.To(
            () =>
            {
                return rt.anchoredPosition;
            },
                v => { rt.anchoredPosition = v; }, new Vector2(0, 0f), 0.3f);
    }

    /// <summary>
    /// 分享按钮事件
    /// </summary>
    //public void OnBtnGooglePlayClick(Text text)
    //{
    //    AudioMgr._instance.PlayFx("Btn");
    //    if (GooglePlayService.Instance.GetLoginState())
    //    {
    //        GooglePlayService.Instance.ShowAllAcheivement();
    //    }
    //    else
    //    {
    //        GooglePlayService.Instance.LoginIn(
    //            (sucess)=>
    //            {
    //                if (sucess)
    //                {
    //                    text.text = "查看";
    //                }
    //            });
    //    }
    //}

    /// <summary>
    /// 关于游戏按钮事件
    /// </summary>
    public void OnBtnAboutAuthorClick()
    {
        Debug.Log("关于游戏");
        AudioMgr._instance.PlayFx("Btn");
        aboutGame.transform.DOScale(new Vector2(1f, 1f), 0.5f);
    }

    /// <summary>
    /// 返回按钮事件
    /// </summary>
    /// <param name="trans"></param>
    public void OnBtnReturnClick(Transform trans)
    {
        AudioMgr._instance.PlayFx("Btn");
        if (trans.parent.name == "AboutGame")
        {
            aboutGame.transform.DOScale(Vector3.zero, 0.5f);
        }
        if (trans.parent.name == "LevelSelect")
        {
            RectTransform rt = levelSelect.GetComponent<RectTransform>();
            DOTween.To(
                () =>
                {
                    return rt.anchoredPosition;
                },
                    v => { rt.anchoredPosition = v; }, new Vector2(-1920f, 0f), 0.3f);
        }
        if (trans.parent.name == "Achievement")
        {
            RectTransform rt = achievement.GetComponent<RectTransform>();
            DOTween.To(() => { return rt.anchoredPosition; },
                v => { rt.anchoredPosition = v; }, new Vector2(0, 1080f), 0.3f);
        }
    }

    /// <summary>
    /// 玩家姓名输入提交
    /// </summary>
    public void OnInputNameSubmit()
    {
        InputField input = inputName.transform.Find("InputName").GetComponent<InputField>();
        if (input.text == "" || input.text.Length > 6)
        {
            inputName.transform.Find("Hint").DOScale(Vector3.one, 0.3f).OnComplete(
                () =>
                {
                    Invoke("HideHint", 1.5f);
                });
        }
        else
        {
            SaveFileMgr.PlayerInfo.playerName = input.text;
            SaveFileMgr.PlayerInfo.bNameExist = true;
            SaveFileMgr.Instance.SaveFile();
            inputName.gameObject.SetActive(false);
            //回调开始按钮
            OnBtnStartClick();
        }
    }
    void HideHint()
    {
        inputName.transform.Find("Hint").DOScale(Vector3.zero, 1f);
    }

    public void OpenUrl()
    {
        Application.OpenURL("http://weibo.com/Jerry12186");
    }
}

