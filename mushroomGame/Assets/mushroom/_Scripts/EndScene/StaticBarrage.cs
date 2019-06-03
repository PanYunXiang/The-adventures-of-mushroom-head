using UnityEngine;
using System.Collections;

class StaticBarrage : MonoBehaviour
{
    public GameObject[] texts;

    private void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].SetActive(false);
        }

        StartCoroutine(ShowTexts(() => { gameObject.SetActive(false); }));
    }

    IEnumerator ShowTexts(System.Action OnFinsh)
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(3f);
        OnFinsh();
    }
}
