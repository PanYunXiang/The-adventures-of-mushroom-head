using UnityEngine;

public enum PlayerState
{
    Idle,
    Run,
    Jump,
    Die
}

public class PlayerController : MonoBehaviour
{
    public static PlayerController _instance;

    private bool bGameover = false;
    private Animator anim;
    private PlayerState state = PlayerState.Idle;
    private bool bJump = true;

    public bool BJump
    {
        get { return bJump; }
        set { bJump = value; }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        ///测试
        if (Input.GetKeyDown(KeyCode.D))
            state = PlayerState.Run;
        if (Input.GetKeyUp(KeyCode.D))
            state = PlayerState.Idle;
        if(Input.GetKeyDown(KeyCode.J))
        {
            state = PlayerState.Jump;
        }
    }

    void LateUpdate()
    {
        if (!bGameover)
        {
            switch (state)
            {
                case PlayerState.Idle:
                    Idle();
                    break;
                case PlayerState.Run:
                    Run();
                    break;
                case PlayerState.Jump:
                    Jump();
                    break;
                case PlayerState.Die:
                    Die();
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// 跑动动画
    /// </summary>
    private void Run()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Die", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Idle", false);
        int symbol = transform.localScale.x > 0 ? 1 : -1;
        transform.position += transform.right * Time.deltaTime * 2f * symbol;
    }

    /// <summary>
    /// 闲置动画
    /// </summary>
    private void Idle()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("Run", false);
        anim.SetBool("Die", false);
        anim.SetBool("Jump", false);
    }

    /// <summary>
    /// 跳跃动画
    /// </summary>
    private void Jump()
    {
        anim.SetBool("Jump", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Run", false);
        anim.SetBool("Die", false);
        if (bJump)
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8f);

        bJump = false;
    }

    /// <summary>
    /// 死亡动画
    /// </summary>
    private void Die()
    {
        bJump = false;
        bGameover = true;
        anim.SetBool("Jump", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Run", false);
        anim.SetBool("Die", true);
        LevelMgr._instacne.ShowLosePanel(++LevelMgr.DieCount);
/*        Debug.Log(LevelMgr.DieCount);*/

        SaveFileMgr.PlayerInfo.dieCount++;
        SaveFileMgr.Instance.SaveFile();
        if (SaveFileMgr.PlayerInfo.dieCount == 1)
        {
            SaveFileMgr.Instance.AddAchievement("First Blood");
            //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_first_blood);
        }
        if (SaveFileMgr.PlayerInfo.dieCount >= 100)
        {
            SaveFileMgr.Instance.AddAchievement("百死成圣");
            //GooglePlayService.Instance.UnlockAchievement(GPGSIds.achievement_11);
        }
    }

    public void ChangeState(PlayerState state)
    {
        this.state = state;
    }
    public PlayerState GetState()
    {
        return state;
    }
}
