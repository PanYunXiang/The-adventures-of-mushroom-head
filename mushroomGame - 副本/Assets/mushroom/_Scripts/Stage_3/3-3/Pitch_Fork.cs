using UnityEngine;

public class Pitch_Fork : MonoBehaviour
{
    public GameObject forkOfPlayer;
    public GameObject chosePanel;

    [SerializeField]
    public bool bPickUp = true;

    private bool bChose = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (bPickUp)
                chosePanel.SetActive(true);
        }
    }

    public void OnBtnChoseClick()
    {
        forkOfPlayer.SetActive(true);
        gameObject.SetActive(false);
        chosePanel.SetActive(false);
        forkOfPlayer.SetActive(true);
    }

    public void OnBtnUnchoseClick()
    {
        chosePanel.SetActive(false);
    }
}
