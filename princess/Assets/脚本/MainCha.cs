using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCha : MonoBehaviour
{
    [Header("主角移动速度")]
    [SerializeField] private float speed;

    Rigidbody2D rigidbody2d;
    
    [Header("主角死亡后尸体")]
    [SerializeField]GameObject dieObj;

    /// <summary>
    /// 主角状态
    /// </summary>
    enum enum_chaState {idle,die,climb}

    /// <summary>
    /// 当前主角当前状态
    /// </summary>
    enum_chaState chaState;

    /// <summary>
    /// 游戏管理
    /// </summary>
    GM gm;

    /// <summary>
    /// 角色是否在地面上
    /// </summary>
    [HideInInspector]
    public bool isOnGround;

    bool isSpring;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("游戏管理").GetComponent<GM>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        switch (chaState)
        { 
        case enum_chaState.idle: 
                if (isOnGround&&!isSpring)
                    Move();
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (isSpring && col.gameObject.tag == "Tag_ground")
        {
            isSpring = false;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tag_ground"|| col.gameObject.tag == "Tag_box")
        {
            isOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tag_ground" || col.gameObject.tag == "Tag_box" && isOnGround)
        {
            isOnGround = false;
            if (!isSpring)
            { rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x / 4, rigidbody2d.velocity.y); }//降低在空中的速度
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Tag_spring")
        {
            isSpring = true;
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
        }
        if (col.tag=="Tag_die")
        {
            Die();//角色死亡
        }
    }

    /// <summary>
    /// 角色a左右移动
    /// </summary>
    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);//角色朝向左
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
            transform.rotation=Quaternion.Euler(0,180,0);//角色朝向右
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }
    }

    /// <summary>
    /// 角色死亡
    /// </summary>
    private void Die()
    {
        //第一次进入死亡状态
        if(chaState!=enum_chaState.die)
        {
            if(gm.Del_ChaDie!=null)
            {
                gm.Del_ChaDie();//向gm触发委托，报告玩家死亡
            }
            GameObject.Instantiate(dieObj,transform.position,Quaternion.Euler(0,0,0));//创建一个尸体
            chaState = enum_chaState.die;//修改本体状态
            Destroy(gameObject);//删除本体
        }
    }

}
