using UnityEngine;

class PoisonSwtich : MonoBehaviour
{
    public VideoController video;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            video.gameObject.SetActive(true);
            //video.PlayVideo();
        }
    }
}