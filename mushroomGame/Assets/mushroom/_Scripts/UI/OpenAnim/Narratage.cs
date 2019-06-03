using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

/// <summary>
/// 旁白管理
/// </summary>
public class Narratage : MonoBehaviour
{
    public Text narratageText;
    public Image img;

    void Start()
    {
        ShowNarratage();
    }

    void ShowNarratage()
    {
        List<ChatContents> openNarratage = GameModels.GetChatList("ChatContentList").OpenAnim;
        narratageText.DOText(DealStr(openNarratage[0].content), 5f).SetEase(Ease.Linear).OnComplete(() => 
        {
            img.sprite = Resources.Load<Sprite>(VariablePath.Image_OpenAnim + openNarratage[0].headImg);
            img.DOFade(1, 2f).OnComplete(() => { Mgr._instance.SetBtnVisible(true); });
        });
    }

    /// <summary>
    /// 处理换行等特殊情况
    /// </summary>
    /// <param name="jsonStr"></param>
    string DealStr(string str)
    {
        string newJsonStr = str;
        if (str.Contains("\\r\\n"))
        {
            newJsonStr = str.Replace("\\r\\n", "\r\n");
        }
        return newJsonStr;
    }
}
