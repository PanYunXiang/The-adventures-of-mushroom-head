using UnityEngine;
using System.Text.RegularExpressions;

class Flag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("进入下一关");
            string str = Regex.Replace(ScenesMgr.Instance.LevelInfo, @"[^0-9]+", "");

            char[] temp = str.ToCharArray();
            int stage = int.Parse(temp[0].ToString());
            int level = int.Parse(temp[1].ToString());

            int tempLevel = (stage - 1) * VariablePath.Stage_Count + (level - 1);
            if (SaveFileMgr.PlayerInfo.level == tempLevel)
            {
                SaveFileMgr.PlayerInfo.level++;
                SaveFileMgr.Instance.SaveFile();
            }

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
            ScenesMgr.Instance.GetLevelInfo(stage, level);
        }
    }
}
