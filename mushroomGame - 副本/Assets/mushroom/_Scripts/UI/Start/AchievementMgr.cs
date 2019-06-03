using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

class AchievementMgr : MonoBehaviour
{
    public GameObject achievement;//成就的小格子
    public GameObject achievementParent;//用于排列成就
    public Text textCount;
    /// <summary>
    /// 玩家获得成就，用list保存
    /// 只保存成就的名字
    /// </summary>
    List<string> achievementNames = new List<string>();
    //    new List<string>()
    //{
    //    "传火使我快乐",
    //    "宅王--{0}",
    //    "这火我不传"
    //};
    /// <summary>
    /// 所有的成就
    /// </summary>
    List<AchievementModel> allAchievements = new List<AchievementModel>();

    private void Start()
    {
		if (SaveFileMgr.PlayerInfo.achievents != null)
        {
			achievementNames = SaveFileMgr.PlayerInfo.achievents;
            textCount.text = SaveFileMgr.PlayerInfo.achievents.Count + "/" + GameModels.GetAchievement("Achievement").Achievement.Count;
            ShowAchievement();
        }
    }
    
    /// <summary>
    /// 通过名字查找玩家所获得的成就
    /// 用于显示成就界面
    /// </summary>
    /// <returns></returns>
    private List<AchievementModel> FindAchievementsByName()
    {
        List<AchievementModel> achievements = new List<AchievementModel>();
        List<AchievementModel> achievementsTemp = GameModels.GetAchievement("Achievement").Achievement;
        
        ///achievementNames为暂时测试用的
        ///正式的是从存档中查询
        for (int i = 0; i < achievementNames.Count; i++)
        {
            AchievementModel model = new AchievementModel();
            model = achievementsTemp.Find(delegate (AchievementModel a)
            {
                if (a.Name.StartsWith("宅"))
                    a.Name = string.Format(a.Name, SaveFileMgr.PlayerInfo.playerName);
                return a.Name == achievementNames[i];
            });

            achievements.Add(model);
        }

        return achievements;
    }

    /// <summary>
    /// 显示成就
    /// </summary>
    public void ShowAchievement()
    {
        List<AchievementModel> achievements = new List<AchievementModel>();
        achievements = ReSort();

        for (int i = 0; i < achievements.Count; i++)
        {
            GameObject go = Instantiate(achievement) as GameObject;
            if (achievements[i].Name.StartsWith("宅"))
            {
                ///Jerry位测试使用
                ///正式的从玩家存档中读取
				achievements[i].Name = string.Format("宅王---{0}", SaveFileMgr.PlayerInfo.playerName);
            }
			go.GetComponent<Achievment>().SetInfo(achievements[i].Image, achievements[i].Name, achievements[i].Describe, SaveFileMgr.PlayerInfo.time[i]);
            go.transform.parent = achievementParent.transform;
            go.transform.localScale = Vector3.one;
        }
    }

    /// <summary>
    /// 排序，确保宅王成就放在第一位
    /// </summary>
    /// <returns></returns>
    List<AchievementModel> ReSort()
    {
        List<AchievementModel> achievements = new List<AchievementModel>();
        achievements = FindAchievementsByName();

        for (int i = 0; i < achievements.Count; i++)
        {
            ///这个有点问题，TODO
            if (achievements[i].Name.StartsWith("宅"))
            {
                AchievementModel aTemp = new AchievementModel();
                aTemp = achievements[i];
                achievements.Remove(achievements[i]);
                achievements.Insert(0, aTemp);
            }
        }

        return achievements;
    }
}