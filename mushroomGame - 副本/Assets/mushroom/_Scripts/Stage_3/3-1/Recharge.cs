using UnityEngine;

class Recharge : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);

        if (LevelMgr.DieCount > 2)
        {
            gameObject.SetActive(true);
        }
    }

    public void OnRecharge()
    {
        SaveFileMgr.Instance.AddAchievement("充钱变强");
        //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_9);
        gameObject.SetActive(false);
        Invoke("NextLevel", 1.5f);
    }

    public void OnUnRecharge()
    {
        ScenesMgr.Instance.ResetLevel();
        gameObject.SetActive(false);
    }

    void NextLevel()
    {
        Debug.Log("进入下一关");
        string str = System.Text.RegularExpressions.Regex.Replace(ScenesMgr.Instance.LevelInfo, @"[^0-9]+", "");

        char[] temp = str.ToCharArray();
        int stage = int.Parse(temp[0].ToString());
        int level = int.Parse(temp[1].ToString());

        int tempLevel = (stage - 1) * VariablePath.Stage_Count + (level - 1);
        if (SaveFileMgr.PlayerInfo.level == tempLevel)
            SaveFileMgr.PlayerInfo.level++;

        if (level == 4 && stage < 4)
        {
            stage++;
            level = 1;

        }
        else
        {
            level++;
        }
        LevelMgr._instacne.ShowWinPanel();
        SaveFileMgr.Instance.SaveFile();
        ScenesMgr.Instance.GetLevelInfo(stage, level);
    }
}
