using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mgr : MonoBehaviour
{
    public static Mgr _instance;

    public GameObject abstractPanel;
    public GameObject chatPanel;
    public GameObject goOnBtn;

    void Awake()
    {
        _instance = this;
    }


    public void SetBtnVisible(bool visible)
    {
        goOnBtn.SetActive(visible);
    }

    /// <summary>
    /// 继续按钮
    /// </summary>
    public void GoOnBtn()
    {
        goOnBtn.SetActive(false);

        if (abstractPanel.activeInHierarchy)
        {
            abstractPanel.SetActive(false);
            chatPanel.SetActive(true);
        }
        else if(chatPanel.activeInHierarchy)
        {
            //加载开始界面
            ScenesMgr.Instance.LoadScene(VariablePath.StartScene);
        }
    }
}
