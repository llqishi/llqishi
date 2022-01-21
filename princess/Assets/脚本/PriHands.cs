using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriHands : MonoBehaviour
{
    [SerializeField]Princess pri;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tag_wall" || col.gameObject.tag == "Tag_box")
        {
            pri.speed *= -1;
        }
    }
}
