using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    GM gm;

    [Header("公主移动的速度")]
    [SerializeField]
    public float speed;

    Rigidbody2D rb;

    /// <summary>
    /// 是否在地面上
    /// </summary>
    [HideInInspector]
    public bool isOnGround;

    bool isSpring;

    /// <summary>
    /// 是否已死亡
    /// </summary>
    bool isDie;


    Animator ani;

    void Awake()
    {
        isDie = false;
        gm=GameObject.Find("游戏管理").GetComponent<GM>();
        rb=gameObject.GetComponent<Rigidbody2D>();
        gm.Del_PriGet += PriGet;
        ani = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
       if(isOnGround&&!isDie)PriMove();
    }

    /// <summary>
    /// 公主移动
    /// </summary>
    void PriMove()
    {
        rb.velocity = new Vector2(speed,rb.velocity.y);
        ani.SetFloat("speed", speed);//设置公主动画
    }
    
    /// <summary>
    /// 公主到达
    /// </summary>
    void PriGet()
    {
        speed = 0;
    }

    /// <summary>
    /// 公主死亡
    /// </summary>
    void PriDie()
    {
        //只触发一次死亡
        if(!isDie)
        {
            gm.Del_PriDie();//向gm报告委托
            isDie = true;
            ani.SetBool("die", isDie);
            GetComponent<Collider2D>().isTrigger = true;
            rb.velocity = new Vector2(0, 10);//死亡时向上弹起
            rb.gravityScale = 2;//加速下落视觉效果
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(isSpring&&col.gameObject.tag== "Tag_ground")
        {
            isSpring = false;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tag_ground" || col.gameObject.tag == "Tag_box")
        {
            isOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tag_ground"|| col.gameObject.tag == "Tag_box")
        {
            isOnGround = false;
            if(!isSpring)
            {
                rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Tag_spring")
        {
            isSpring = true;
            transform.position=new  Vector2 (transform.position.x,transform.position.y+0.1f);
        }
        if (col.tag == "Tag_die")
        {
            PriDie();
        }
    }
}
