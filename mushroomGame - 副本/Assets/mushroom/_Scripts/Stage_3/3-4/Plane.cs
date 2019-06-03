using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPos;
    public static Plane _instance;
    public GameObject linghting;

    /// <summary>
    /// 消灭的滑稽个数
    /// </summary>
    public int HuajiCount { set; get; }

    private bool bGameover = false;

    public enum PlaneState
    {
        Idle,
        Right,
        Left,
        Fire,
        Die
    }
    private PlaneState state;

    void Awake()
    {
        _instance = this;
        state = PlaneState.Idle;
        HuajiCount = 0;
    }

    private void Update()
    {
        if (!bGameover)
        {
            switch (state)
            {
                case PlaneState.Idle:
                    break;
                case PlaneState.Right:
                    MoveRight();
                    break;
                case PlaneState.Left:
                    MoveLeft();
                    break;
                case PlaneState.Fire:
                    break;
                case PlaneState.Die:
                    Die();
                    break;
                default:
                    break;
            }
        }
    }

    void MoveRight()
    {
        transform.position += transform.right * Time.deltaTime * 2f;
    }
    void MoveLeft()
    {
        transform.position -= transform.right * Time.deltaTime * 2f;
    }

    public void Fire()
    {
        if (!bGameover)
        {
            GameObject go = Instantiate(bullet) as GameObject;
            go.transform.parent = bulletPos.transform;
            go.transform.localPosition = Vector3.zero;
            go.GetComponent<Bullet>().Fly();
        }
    }
    void Die()
    {
        bGameover = true;
        LevelMgr.DieCount++;
        LevelMgr._instacne.ShowLosePanel(LevelMgr.DieCount);
    }

    public void ChangeState(PlaneState state)
    {
        this.state = state;
    }

    public void SetLightingVisable()
    {
        linghting.SetActive(true);
    }
}
