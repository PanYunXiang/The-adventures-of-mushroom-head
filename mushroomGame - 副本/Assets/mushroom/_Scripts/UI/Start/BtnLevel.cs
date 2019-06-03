using UnityEngine;
using UnityEngine.UI;

public class BtnLevel : MonoBehaviour
{
    public int stage;
    public int level;
    
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        if (btn != null)
        {
            
            btn.onClick.AddListener(
                () => 
                {
                    AudioMgr._instance.PlayFx("Btn");
                    ScenesMgr.Instance.LoadScene(VariablePath.LoadScene);
                    ScenesMgr.Instance.GetLevelInfo(stage, level);
                });
        }

        Init();
    }

    /// <summary>
    /// 初始化按钮外观
    /// </summary>
    void Init()
    {
        Transform imgLock = transform.Find("Lock");
        Transform num = transform.Find("Text");
        int info = (stage - 1) * VariablePath.Stage_Count + (level - 1);
        if (info <= SaveFileMgr.PlayerInfo.level)
        {
            imgLock.gameObject.SetActive(false);
            num.gameObject.SetActive(true);
            btn.enabled = true;
        }
        else
        {
            imgLock.gameObject.SetActive(true);
            num.gameObject.SetActive(false);
            btn.enabled = false;
        }
    }
}
