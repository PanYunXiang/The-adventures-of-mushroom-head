using UnityEngine;

/// <summary>
/// 全局控制
/// </summary>
public class GameController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Start()
    {
        Debug.Log(Application.version);

        ///测试
        //SaveFileMgr.Instance.ClearSave();
        ///添加成就
        //SaveFileMgr.Instance.AddAchievement("TAN 90");
        //SaveFileMgr.Instance.AddAchievement(string.Format("宅王--{0}", SaveFileMgr.PlayerInfo.playerName));
        //SaveFileMgr.Instance.SaveFile();
        ///
        Debug.Log(SaveFileMgr.PlayerInfo.level);
        Debug.Log(PlayerPrefs.GetString(VariablePath.Save));

        if (SaveFileMgr.PlayerInfo.openAnim == 1)
        {
            ScenesMgr.Instance.LoadScene(VariablePath.StartScene);
        }
        else if (SaveFileMgr.PlayerInfo.openAnim == 0)
        {
            SaveFileMgr.PlayerInfo.openAnim = 1;
            SaveFileMgr.Instance.SaveFile();
            ScenesMgr.Instance.LoadScene(VariablePath.OpenAnimScene);
        }

        ///删除存档
    }
}
