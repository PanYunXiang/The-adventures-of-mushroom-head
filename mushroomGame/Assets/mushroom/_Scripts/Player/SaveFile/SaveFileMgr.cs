using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SaveFileMgr
{
    private static SaveFileMgr instance;

    private static PlayerInfo info;
    
    public static SaveFileMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveFileMgr();
            }
            return instance;
        }
    }

    public static PlayerInfo PlayerInfo
    {
        get
        {
            if (info == null)
            {
                info = new PlayerInfo();
                info = Instance.GetFile();
                if (!info.bExist)
                {
                    info.openAnim = 0;
                    info.level = 0;
                    info.achievents = new List<string>();
                    info.time = new List<string>();
                    info.playerName = "";
                    info.bNameExist = false;
                    info.dieCount = 0;
                    info.bExist = false;
                    info.huaJiCoin = 0;
                    Instance.SaveFile();
                }
            }
            return info;
        }
        set
        {
            info = value;
        }
    }

    /// <summary>
    /// 保存游戏进度信息
    /// </summary>
    public void SaveFile()
    {
        if (PlayerInfo != null)
        {
            if (!PlayerInfo.bExist)
                PlayerInfo.bExist = true;
            string str = JsonUtility.ToJson(PlayerInfo, true);
            PlayerPrefs.SetString(VariablePath.Save, str);
        }
    }

    public PlayerInfo GetFile()
    {
        string strJson = PlayerPrefs.GetString(VariablePath.Save);
        PlayerInfo saveInfo;
        saveInfo = JsonUtility.FromJson<PlayerInfo>(strJson);
        if (saveInfo == null)
            saveInfo = new PlayerInfo();
        return saveInfo;
    }

    /// <summary>
    /// 添加成就
    /// </summary>
    public void AddAchievement(string achievementName)
    {
        if (PlayerInfo.achievents.Contains(achievementName)) return;
        LevelMgr._instacne.ShowAchievement(achievementName);
        PlayerInfo.achievents.Add(achievementName);
        PlayerInfo.time.Add(System.DateTime.Now.ToString("yyyy-MM-dd"));
        
        SaveFile();
    }

    /// <summary>
    /// 清空存档
    /// </summary>
    public void ClearSave()
    {
        PlayerPrefs.DeleteKey(VariablePath.Save);
    }
}
