using UnityEngine;

public class BanBen : MonoBehaviour
{
    /// <summary>
    /// 记录玩家跳跃的次数
    /// 用于通关和解锁成就“秘籍：反复横跳”
    /// </summary>
    public static int secretCount = 0;
    private void Start()
    {
        secretCount = 0;
    }
}
