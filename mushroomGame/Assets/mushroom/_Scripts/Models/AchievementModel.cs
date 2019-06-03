using System.Collections.Generic;

[System.Serializable]
public class AchievementModel
{
    public string Name;
    public string Describe;
    public string Image;
}

[System.Serializable]
public class AchievementList
{
    public List<AchievementModel> Achievement;
}

