using System.Collections.Generic;

[System.Serializable]
public class PlayerInfo
{
    /// <summary>
    /// 是否过开场动画
    /// 0.表示没有过，开始游戏的时候需要过开场动画
    /// 1.表示过了，则直接进入开始界面
    /// </summary>
    public int openAnim;

    /// <summary>
    /// 玩家当前的关卡
    /// 0-15
    /// </summary>
    public int level;

    /// <summary>
    /// 玩家获得的成就
    /// </summary>
    public List<string> achievents;
    /// <summary>
    /// 获得成就的时间
    /// 与achievement的索引相同
    /// </summary>
    public List<string> time;

    /// <summary>
    /// 玩家的名字
    /// </summary>
    public string playerName;
    /// <summary>
    /// 玩家是否输入流姓名
    /// 默认为false
    /// </summary>
    public bool bNameExist;

    /// <summary>
    /// 玩家的死亡次数
    /// </summary>
    public int dieCount;

    /// <summary>
    /// 存档是否存在
    /// 默认不存在
    /// </summary>
    public bool bExist = false;

    /// <summary>
    /// 获得的滑稽币个数
    /// </summary>
    public int huaJiCoin;
}

