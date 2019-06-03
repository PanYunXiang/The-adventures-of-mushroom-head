using System.Collections;
using UnityEngine;

public class CutDown : MonoBehaviour
{
    public TextMesh timeText;
    public bool bCutDown = true;
    void Start()
    {
        StartCoroutine(TimeCut(5 * (LevelMgr.DieCount + 1)));
    }

    IEnumerator TimeCut(int time)
    {
        while (time >= 0 && bCutDown)
        {
            timeText.text = time.ToString() + "s";
            yield return new WaitForSeconds(1f);
            time--;
            if (time <= 0)
                Plane._instance.ChangeState(Plane.PlaneState.Die);
        }
    }
}
