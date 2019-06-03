using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class DialogMgr : MonoBehaviour
{
    public Text dialog0;
    public Text dialog1;
    public GameObject video;

    private List<LastLevelModel> contents;

    private void Start()
    {
        contents = GameModels.GetContent("Dialog").Dialog;

        StartCoroutine(SetDialog(OnDialogEnd));
    }

    IEnumerator SetDialog(System.Action action = null)
    {
        if (contents != null)
        {
            for (int i = 0; i < contents.Count; i++)
            {
                if (contents[i].teller == "1")
                {
                    dialog0.transform.parent.gameObject.SetActive(true);
                    dialog0.text = contents[i].content;
                    yield return new WaitForSeconds(2f);
                    dialog0.transform.parent.gameObject.SetActive(false);
                }
                else if (contents[i].teller == "0")
                {
                    dialog1.transform.parent.gameObject.SetActive(true);
                    dialog1.text = contents[i].content;
                    yield return new WaitForSeconds(2f);
                    dialog1.transform.parent.gameObject.SetActive(false);
                }
            }
            action();
        }
    }

    void OnDialogEnd()
    {
        video.SetActive(true);
        //video.GetComponent<VideoController>().PlayVideo();
    }
}
