using System.Collections.Generic;

[System.Serializable]
public class PoisonTip
{
    public string Content;
}

[System.Serializable]
public class Tip
{
    public List<PoisonTip> Tips;
}

