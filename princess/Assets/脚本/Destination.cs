using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    GM gm;

    void Awake()
    {
        gm=GameObject.Find("游戏管理").GetComponent<GM>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Tag_pri")
        {
            Get();//关卡完成
        }
    }

    /// <summary>
    /// 关卡完成
    /// </summary>
    void Get()
    {
        if(gm.gameState==GM.enum_gameState.normal)
        {
            gm.Del_PriGet();
        }
    }
}
