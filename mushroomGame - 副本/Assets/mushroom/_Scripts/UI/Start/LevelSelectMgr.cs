using UnityEngine;
using DG.Tweening;

public class LevelSelectMgr : MonoBehaviour
{
    public RectTransform stages;

    private int index = 0;

    public void OnBtn_R()
    {
        Debug.Log("向右移动");
        AudioMgr._instance.PlayFx("Btn");
        if (index == 3) return;
        index++;
        DOTween.To(
            () => { return stages.anchoredPosition; },
            v => { stages.anchoredPosition = v; },
            new Vector2(-450f * index, 0), 1f);
    }
    public void OntBtn_L()
    {
        Debug.Log("向左移动");
        AudioMgr._instance.PlayFx("Btn");
        if (index == 0) return;
        index--;
        DOTween.To(
            () => { return stages.anchoredPosition; },
            v => { stages.anchoredPosition = v; },
            new Vector2(-450f * index, 0), 1f);
    }
}

