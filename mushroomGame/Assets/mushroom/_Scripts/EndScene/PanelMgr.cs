using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

class PanelMgr : MonoBehaviour
{
    public GameObject imagePanel;
    public Text text;
    public GameObject inputFiled;
    public Transform barrageParent;
    public GameObject barrages;
    public GameObject moveBarrage;

    private void Start()
    {
        Invoke("ShowText", 0.5f);
    }

    void ShowText()
    {
        text.DOText(@"多谢你忍住折磨通关这款完（la）美（ji）的游戏，如果您有什么好的建议和意见的话，请微博@Jerry12186。

程序：Jerry12186
天（keng）才（die）设计师：Jerry12186
灵魂P图师：Jerry12186

为了安慰你在游戏受伤的幼小心灵，下面奉上我老婆一张素描。", 15f).SetEase(Ease.Linear).OnComplete(ShowMyGrilFriend);
    }

    void ShowMyGrilFriend()
    {
        RectTransform rt = imagePanel.GetComponent<RectTransform>();
        DOTween.To(
            () =>
            { return rt.anchoredPosition; },
            v => { rt.anchoredPosition = v; },
            new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y - 1000), 5f)
            .SetEase(Ease.Linear).OnComplete(
            () =>
            {
                inputFiled.SetActive(true);
                barrages.SetActive(true);
            });
    }

    public void OnSumbit()
    {
        InputField input = inputFiled.GetComponent<InputField>();
        if (input.text != "")
        {
            GameObject go = Instantiate(moveBarrage) as GameObject;
            go.transform.parent = barrageParent;
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(800f, Random.Range(-140, 280));
            go.GetComponent<MoveBarrage>().SetText(input.text);
            if(input.text.Contains("我老婆")||input.text.Contains("我的老婆"))
            {
                Invoke("ShowAchievement", 0.5f);
            }
            input.text = "";
        }
    }

    void ShowAchievement()
    {
        SaveFileMgr.Instance.AddAchievement("你的老婆不可能这么可爱");
        //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_6, null);
    }
}