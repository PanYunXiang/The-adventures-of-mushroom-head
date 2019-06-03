using UnityEngine;
using DG.Tweening;

class RoadTrap : MonoBehaviour
{
    public GameObject mashroom;
    public GameObject lightning;
    public GameObject saw;
    public GameObject flower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            MashroomAnim();
            LightningAnim();
            SawAnim();
            FlowerAnim();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            MashroomAnim();
            LightningAnim();
            SawAnim();
            FlowerAnim();
        }
    }
    #region 陷阱动画
    void MashroomAnim()
    {
        if (mashroom != null)
        {
            mashroom.SetActive(true);
            mashroom.GetComponent<MashroomTrap>().MashroomMove();
        }
    }

    void LightningAnim()
    {
        if (lightning != null)
        {
            lightning.SetActive(true);
            lightning.GetComponent<SpriteRenderer>().DOFade(0, 0.5f).SetLoops(-1, LoopType.Restart);
        }
    }

    void SawAnim()
    {
        if (saw != null)
        {
            saw.SetActive(true);
            saw.GetComponent<DropSaw>().Drop();
        }
    }

    void FlowerAnim()
    {
        if (flower != null)
        {
            flower.transform.DOLocalMoveY(1.23f, 0.5f).SetEase(Ease.Linear);
        }
    }
    #endregion
}

