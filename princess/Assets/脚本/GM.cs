using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    /// <summary>
    /// 玩家死亡
    /// </summary>
    public delegate void del_chaDie();

    /// <summary>
    /// 游戏开始
    /// </summary>
    public delegate void del_gameStart();

    /// <summary>
    /// 游戏状态
    /// </summary>
    public enum enum_gameState{wait,normal,win,lose,};

    /// <summary>
    /// 游戏进行状态
    /// </summary>
    public enum_gameState gameState;

    /// <summary>
    /// 公主死亡
    /// </summary>
    public delegate void del_priDie();

    /// <summary>
    /// 公主到达终点
    /// </summary>
    public delegate void del_priGet();

    /// <summary>
    /// 公主到达终点时触发
    /// </summary>
    public del_priGet Del_PriGet;

    public del_gameStart Del_GameStart;

    /// <summary>
    /// 玩家死亡时触发委托
    /// </summary>
    public del_chaDie Del_ChaDie;

    /// <summary>
    /// 公主死亡时触发
    /// </summary>
    public del_priDie Del_PriDie;

    /// <summary>
    /// 复活点的位置坐标
    /// </summary>
    [HideInInspector]
    public Vector2 BindPos;

    [Header("游戏主角")]
    [SerializeField] GameObject MainCha;

    [Header("公主")]
    [SerializeField] GameObject PriCha;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Del_GameStart += CreateNewCha;
        Del_GameStart += CreateNewPri;
        Del_ChaDie += CreateNewCha;
    }

    void Start()
    {
        Del_GameStart();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 关卡状态控制
    /// </summary>
    private void LevelControl()
    {
        switch(gameState)
        {

        }
    }

    /// <summary>
    /// 创建新的主角
    /// </summary>
    private void CreateNewCha()
    {
        Instantiate(MainCha, BindPos, Quaternion.Euler(0, 0, 0));
    }

    /// <summary>
    /// 创建公主
    /// </summary>
    private void CreateNewPri()
    {
        Instantiate(PriCha, BindPos, Quaternion.Euler(0, 0, 0));
    }

    /// <summary>
    /// 关卡完成
    /// </summary>
    private void LevelComplete()
    {
        if(gameState==enum_gameState.normal)
        {
            gameState = enum_gameState.win;
        }
    }

}
