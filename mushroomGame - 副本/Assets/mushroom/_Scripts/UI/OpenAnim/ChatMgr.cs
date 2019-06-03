using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 对话内容管理
/// </summary>
public class ChatMgr : MonoBehaviour
{
    public GameObject mysteryMen;//对方对话框
    public GameObject mogutou;//自己的对话框

    public Text writeText;

    void Start()
    {
        StartCoroutine(ShowDialog());
    }

    #region 对话控制
    public IEnumerator ShowDialog()
    {
        List<ChatContents> chatList = GameModels.GetChatList("ChatContentList").ChatContentList;

        for (int i = 0; i < chatList.Count; i++)
        {
            if (chatList[i].teller == "1")//对方信息
            {
                GameObject go = Instantiate(mysteryMen) as GameObject;
                go.transform.parent = transform;
                go.transform.localPosition = new Vector3(-590f, 180 - int.Parse(chatList[i].id) * 100 + 100);
                go.GetComponent<ChatContent>().SetContent(chatList[i].headImg, chatList[i].content);
                yield return new WaitForSeconds(1f); 
                Write(chatList[i + 1].content);
                yield return new WaitForSeconds(3.5f);
            }
            else if (chatList[i].teller == "0")//自己的信息
            {
                GameObject go = Instantiate(mogutou) as GameObject;
                go.transform.parent = transform;
                go.transform.localPosition = new Vector3(560f, 180 - int.Parse(chatList[i].id) * 100 + 100);
                go.GetComponent<ChatContent>().SetContent(chatList[i].headImg, chatList[i].content);
                yield return new WaitForSeconds(2.5f); 
            }
        }
        Mgr._instance.SetBtnVisible(true);
    }

    void Write(string content)
    {
        writeText.DOText(content, 3f).SetEase(Ease.Linear).OnComplete(() => { writeText.text = ""; });
    }
    #endregion


}
