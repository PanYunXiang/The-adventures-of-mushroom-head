using UnityEngine.Advertisements;

public class UnityAds
{
    private static UnityAds instacne;
    private UnityAds() { }

    public static UnityAds Instance
    {
        get
        {
            if (instacne == null)
            {
                instacne = new UnityAds();
                //Advertisement.Initialize(Advertisement.gameId);
            }
            return instacne;
        }
    }

    /// <summary>
    /// 播放广告
    /// </summary>
    public void PlayAds()
    {
        //if (!Advertisement.isInitialized)
        //{
        //    DebugTool.Instance.LogError("广告未被初始化");
        //}
        //else if (!Advertisement.IsReady())
        //{
        //    DebugTool.Instance.LogError("广告未就绪");
        //}
        //else
        //{
        //    ShowOptions options = new ShowOptions
        //    {
        //        resultCallback = (result) =>
        //        {
        //            switch (result)
        //            {
        //                case ShowResult.Failed:
        //                    DebugTool.Instance.Log("广告播放失败！");
        //                    break;
        //                case ShowResult.Skipped:
        //                    DebugTool.Instance.Log("广告被跳过！");
        //                    break;
        //                case ShowResult.Finished:
        //                    DebugTool.Instance.Log("广告播放完成");
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    };
        //    Advertisement.Show(options);
        //}
    }
}
