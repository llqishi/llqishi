using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bind : MonoBehaviour
{
    GM gm;

    void Awake()
    {
        gm = GameObject.Find("游戏管理").GetComponent<GM>();
        Vector2 v2 = gameObject.transform.position;
        v2.y += 0.5f;
        gm.BindPos =v2 ;//关卡开始时将此物体坐标赋予游戏管理
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
