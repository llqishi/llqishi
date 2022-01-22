using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spring : MonoBehaviour
{
    [Header("垂直作用力")]
    [SerializeField] float verticalForce;

    [Header("水平作用力")]
    [SerializeField] float horizontalForce;

    [Header("弹簧弹起图片")]
    [SerializeField]Sprite picOn;

    [Header("弹簧回落图片")]
    [SerializeField]Sprite picOff;

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Tag_cha"|| col.gameObject.tag == "Tag_pri" || col.gameObject.tag == "Tag_box")
            {
            //物体在弹簧左边，向右弹
            if(col.gameObject.transform.position.x<transform.position.x)
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalForce, verticalForce);
            }
            else//否则向左弹
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontalForce, verticalForce);
            }
            SpringOn();
            }
    }

    private void SpringOn()
    {
        GetComponent<SpriteRenderer>().sprite = picOn;
        Invoke("SpringOff", 0.75f);
    }
    private void SpringOff()
    {
        GetComponent<SpriteRenderer>().sprite = picOff;
    }
}
