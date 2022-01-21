using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBoard : MonoBehaviour
{
    [SerializeField]
    [Header("坠落时间")]
    float fallDownTime;

    void OnCollisionEnter2D(Collision2D col)
    {
       if(col.gameObject.tag=="Tag_pri"|| col.gameObject.tag == "Tag_box"|| col.gameObject.tag == "Tag_cha")
        {
            Invoke("Fall", fallDownTime);//定时后掉落
        }
    }
    
    /// <summary>
    /// 平台掉落
    /// </summary>
    private void Fall()
    {
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().gravityScale = 3;
        Destroy(gameObject, 2);//2s后销毁平台
    }
}
