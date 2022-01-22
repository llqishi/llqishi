using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXM : MonoBehaviour
{
    [Header("胜利粒子特效")]
    [SerializeField] GameObject winSfx;

    GM gm;

    void Awake()
    {
        gm = GetComponent<GM>();
        gm.Del_PriGet += Win;
    }

    public void Win()
    {
        InvokeRepeating("PlaySfx", 0,1);
    }

    /// <summary>
    /// 创建胜利粒子效果
    /// </summary>
    private void PlaySfx()
    {
        if(gm.gameState==GM.enum_gameState.win)
        {
            Vector2 v2 = new Vector2(Random.Range(-7.1f, 7.1f), Random.Range(-1.1f, 1.1f));
            Instantiate(winSfx, v2, Quaternion.Euler(0, 0, 0));
        }
    }
}
