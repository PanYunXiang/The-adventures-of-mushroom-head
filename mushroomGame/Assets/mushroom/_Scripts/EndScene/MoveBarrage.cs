using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

class MoveBarrage : MonoBehaviour
{
    [Tooltip("延迟时间")]
    public int delayTime;
    public bool bPlay = true;

    private Text text;

    private void Start()
    {
        if (bPlay)
        {
            RectTransform rt = GetComponent<RectTransform>();
            DOTween.To(() => { return rt.anchoredPosition; }, v => { rt.anchoredPosition = v; }, new Vector2(-740, rt.anchoredPosition.y), 15f)
                .SetEase(Ease.Linear).SetDelay(delayTime);
        }
    }
    public void SetText(string str)
    {
        text = GetComponent<Text>();
        if (text != null)
        {
            text.text = str;
            bPlay = true;
            Start();
        }
    }
}
