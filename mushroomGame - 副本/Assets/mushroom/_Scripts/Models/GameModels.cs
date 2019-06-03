using System.Collections.Generic;
using UnityEngine;

public class GameModels
{
    /// <summary>
    /// 读取开始开场动画中的配置文件
    /// </summary>
    /// <returns></returns>
    public static ChatList GetChatList(string fileName)
    {
        ChatList chatList = new ChatList();
        string path = VariablePath.Config_OpenAnim + fileName;
        string jsonStr = Resources.Load<TextAsset>(path).ToString();
        chatList = JsonUtility.FromJson<ChatList>(jsonStr);
        return chatList;
    }

    /// <summary>
    /// 读取成就配置文件
    /// </summary>
    /// <param name="fileName">成就配置文件名字</param>
    /// <returns></returns>
    public static AchievementList GetAchievement(string fileName)
    {
        string path = VariablePath.Config_Achievement + fileName;
        string jsonStr = Resources.Load<TextAsset>(path).ToString();
        AchievementList achievements = new AchievementList();
        achievements = JsonUtility.FromJson<AchievementList>(jsonStr);

        return achievements;
    }

    /// <summary>
    /// 毒鸡汤配置文件读取
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static Tip GetPoisonTip(string fileName)
    {
        string path = VariablePath.Config_LoadScene + fileName;
        string jsonStr = Resources.Load<TextAsset>(path).ToString();
        Tip tips = new Tip();
        tips = JsonUtility.FromJson<Tip>(jsonStr);

        return tips;
    }

    public static LastLevelChat GetContent(string fileName)
    {
        string path = VariablePath.Conig_LastLevel + fileName;
        string jsonStr = Resources.Load<TextAsset>(path).ToString();
        LastLevelChat contents = new LastLevelChat();
        contents = JsonUtility.FromJson<LastLevelChat>(jsonStr);

        return contents;
    }
}
