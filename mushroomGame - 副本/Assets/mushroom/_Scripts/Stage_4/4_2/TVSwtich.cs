using UnityEngine;

class TVSwtich : MonoBehaviour
{
    public VideoController video;
    public GameObject TV;
    public TextMesh textMesh;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            TV.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            ///改变背景音乐
            ///TODO

            ///播放文字
            string content = "FBI WARNING\r\n以下视频可能会给你造成不适,\r\n请紧张的看下去。";
            StartCoroutine(textMesh.GetComponent<TextMeshPrinterEffect>().TpyerEffect(content, 0.2f,
                () =>
                {
                    ///播放视频
                    video.gameObject.SetActive(true);
                    //video.PlayVideo();
                }));


        }
    }
}

