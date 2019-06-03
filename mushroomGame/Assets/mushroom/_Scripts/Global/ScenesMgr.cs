using UnityEngine.SceneManagement;
using UnityEngine;
/// <summary>
/// 负责加载场景
/// </summary>
public class ScenesMgr
{
    private static ScenesMgr _instance;

    private string levelInfo;

    public static ScenesMgr Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ScenesMgr();
            return _instance;
        }
    }

    public string LevelInfo
    {
        get
        {
            return levelInfo;
        }
    }

    /// <summary>
    /// 加载普通场景
    /// </summary>
    /// <param name="sceneName">场景名字</param>
    public void LoadScene(string sceneName)
    {
        Debug.Log(sceneName);
        if (sceneName == VariablePath.LoadScene)
            LevelMgr.DieCount = 0;
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 获取要加载关卡的信息
    /// </summary>
    /// <param name="stage"></param>
    /// <param name="level"></param>
    public void GetLevelInfo(int stage, int level)
    {
        levelInfo = string.Format(VariablePath.Scene_Path, stage, level);
    }

    public void ResetLevel()
    {
        UnityEngine.Debug.Log(levelInfo);
        SceneManager.LoadScene(levelInfo);
    }
}
