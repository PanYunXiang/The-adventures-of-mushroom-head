using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 加载场景毒鸡汤提示
/// </summary>
class LoadSceneMgr : MonoBehaviour
{
    public Text text;
    public Image[] imgs;
    public GameObject btn;
    public GameObject walk;

    private AsyncOperation async;
    private bool bShowBtn = false;

    private void Start()
    {
        UnityAds.Instance.PlayAds();

        if (SaveFileMgr.PlayerInfo.dieCount < 50)
            imgs[0].gameObject.SetActive(true);
        else
            imgs[1].gameObject.SetActive(true);

        text.text = TextContent();

        btn.SetActive(false);
        walk.SetActive(true);

        StartCoroutine(LoadScene());
    }


    string TextContent()
    {
        List<PoisonTip> poisonTips = GameModels.GetPoisonTip("Tips").Tips;
        string content = poisonTips[Random.Range(0, poisonTips.Count)].Content;

        return content;
    }

    private void Update()
    {
        if (!bShowBtn && async.progress == 0.9f)
        {
            Invoke("ShowBtn", 3f);
        }
    }


    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync(ScenesMgr.Instance.LevelInfo);
        async.allowSceneActivation = false;
        yield return async;
    }

    public void OnBtnClick()
    {
        async.allowSceneActivation = true;
    }

    void ShowBtn()
    {
        btn.SetActive(true);
        walk.SetActive(false);
        bShowBtn = true;
    }
}
