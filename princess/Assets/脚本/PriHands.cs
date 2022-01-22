using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriHands : MonoBehaviour
{
    [SerializeField]Princess pri;

    GM gm;

    void Awake()
    {
        gm = GameObject.Find("游戏管理"). GetComponent<GM>();
        gm.Del_PriDie += PriDie;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tag_wall" || col.gameObject.tag == "Tag_box")
        {
            pri.speed *= -1;
        }
    }

    private void PriDie()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
