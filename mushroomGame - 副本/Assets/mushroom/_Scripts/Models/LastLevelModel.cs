using System.Collections.Generic;

[System.Serializable]
public class LastLevelModel
{
    public string teller;
    public string content;
}

[System.Serializable]
public class LastLevelChat
{
    public List<LastLevelModel> Dialog;
}
