using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("跳躍高度"), Range(10, 2000)]
    public int jump = 88;
    [Header("跳躍角度"), Range(0, 100)]
    public float angle = 10;
    [Header("是否死亡"), Tooltip("用來判斷角色是否死亡，true 死亡，false 還沒死亡")]
    public bool dead;
    [Header("剛體")]
    public Rigidbody2D r2d;
    [Header("遊戲管理器")]
    public GameManager game ;
    public GameObject goScore, goGM;

    public AudioSource aud;
    public AudioClip soundJumppm, soundHit, soundAdd;

    /// <summary>
    /// 小雞跳躍方法。
    /// </summary>
    private void Jump()
    {
        if (dead)
        {
            return;
        }
        
        // b如果玩家按下左鍵 
        //KeyCode.Mouse0 =>滑鼠左鍵&手機觸控
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aud.PlayOneShot(soundJumppm, 1.5f); //喇叭.撥放一次音效(音效,音量)
            print("玩家按下左鍵");
            r2d.Sleep();//刪除這個物理系統的所有事情
            r2d.gravityScale = 0.8f; //小雞剛體.重力 = 1;
            r2d.AddForce(new Vector2(0,jump)); //小雞剛體.增加推力 (二維向量=>左右、上下)

            //讓分數顯示、GM顯示
            goScore.SetActive(true);
            goGM.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            r2d.gravityScale = 2.1f;
        }
        //Rigidbody2D.SetRotation(float) 設定角度
        //Rigidbody2D.velocity 加速度(二維向量 x,y)
        r2d.SetRotation(angle * r2d.velocity.y);
    }

    /// <summary>
    /// 小雞死亡方法。
    /// </summary>
    private void Dead()
    {
        print("死亡");
        dead = true;
        game.GameOver();
    }

    //固定幀數 0.002 一幀 => 要控制物理請寫在此事件內
    private void FixedUpdate()
    {
        Jump();
    }

    // OnCollision 碰撞事件，有enter、exit、stay ; Collision2D(碰撞類型 => 存放碰撞到的物件資訊)
    private void OnCollisionEnter2D(Collision2D hit)
    {
        print(hit.gameObject.name);

        if (hit.gameObject.name == "地板")
        {
            Dead();
        }
    }

    //事件: 觸發開始 - 物件必須勾選 isTrigger
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.name.Contains("水管"))
        {
            aud.PlayOneShot(soundHit, 4f);
            Dead();
        }
        
    }

    //事件: 觸發離開 - 物件離開觸發區域執行一次
    private void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.name == "加分" && !dead)
        {
            aud.PlayOneShot(soundAdd, 2f);
            game.AddScore();
        }
    }
}
