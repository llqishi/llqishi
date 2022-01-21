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
    bool isOnGround;

    void Awake()
    {
        gm=GameObject.Find("游戏管理").GetComponent<GM>();
        rb=gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
       if(isOnGround)PriMove();
    }

    /// <summary>
    /// 公主移动
    /// </summary>
    void PriMove()
    {
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }
    
    /// <summary>
    /// 公主死亡
    /// </summary>
    void PriDie()
    {
        gm.Del_PriDie();//向gm报告委托
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tag_ground")
        {
            isOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tag_ground")
        {
            isOnGround = false;
            rb.velocity=new Vector2(rb.velocity.x / 2,rb.velocity.y);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Tag_die")
        {
            PriDie();
        }
    }
}
