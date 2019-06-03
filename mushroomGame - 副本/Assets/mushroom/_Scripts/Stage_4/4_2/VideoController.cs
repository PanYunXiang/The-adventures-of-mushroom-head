using UnityEngine;
using UnityEngine.Video;

class VideoController : MonoBehaviour
{
    private VideoPlayer player;

    public void PlayVideo()
    {
        player = GetComponent<VideoPlayer>();
        player.Play();

        player.loopPointReached += (VideoPlayer v) =>
        {
            gameObject.SetActive(false);
            if (v.clip.name == "4-2")
            {
                SaveFileMgr.Instance.AddAchievement("我要下车");
                //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_12);
            }
            if (v.clip.name == "4-3")
            {
                SaveFileMgr.Instance.AddAchievement("此毒绵绵无绝期");
                //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_7);
            }
            if (v.clip.name == "4-4")
            {
                SaveFileMgr.Instance.AddAchievement("蕉迟但到");
                //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_4);
                Invoke("LoadScene", 1f);
            }
        };
    }

    void LoadScene()
    {
        ScenesMgr.Instance.LoadScene("EndScene");
    }
}
