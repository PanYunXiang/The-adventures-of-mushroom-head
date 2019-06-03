using UnityEngine;

class Huaji : MonoBehaviour
{
    public CutDown cutDown;
    private int count;
    private void Start()
    {
        count = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log(count);
            count--;
            if (count == 0)
            {
                cutDown.bCutDown = false;
                ///玩家胜利
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
                gameObject.SetActive(false);
                LevelMgr._instacne.ShowWinPanel();
                SaveFileMgr.Instance.SaveFile();
                ScenesMgr.Instance.GetLevelInfo(stage, level);
            }
        }
    }
}
