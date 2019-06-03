using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 记录玩家吃到的蘑菇次数
/// 1-4关使用
/// </summary>
public class MashroomCount : MonoBehaviour
{
    public static MashroomCount _instacne;

    private int _count;

    public int Count
    {
        get { return _count; }
        set { _count = value; }
    }

    void Awake()
    {
        _instacne = this;
        Count = 0;
    }
}
