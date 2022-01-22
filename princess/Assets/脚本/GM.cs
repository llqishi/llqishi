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
    public Vector2 BindPos;

    [Header("游戏主角")]
    [SerializeField] GameObject MainCha;

    [Header("公主")]
    [SerializeField] GameObject PriCha;

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);

        Del_GameStart += CreateNewCha;
        Del_GameStart += CreateNewPri;
        Del_GameStart += LevelStart;

        Del_ChaDie += CreateNewCha;

        Del_PriGet += LevelComplete;
        Del_PriDie += LevelLose;
    }

    void Start()
    {
        Del_GameStart();
    }

    void Update()
    {
        LevelControl();
    }

    /// <summary>
    /// 关卡状态控制
    /// </summary>
    private void LevelControl()
    {
        switch (gameState)
        {
            case enum_gameState.lose:if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//失败后按任意键重开
                    Del_GameStart();
                }
                break;
            case enum_gameState.win:if(Input.anyKeyDown)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//胜利后按任意键下一关
                    Del_GameStart();
                }
                break;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//按r重开本关
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
    /// 关卡开始时触发
    /// </summary>
    private void LevelStart()
    {
        gameState = enum_gameState.normal;
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

    private void LevelLose()
    {
        if (gameState == enum_gameState.normal)
        {
            gameState = enum_gameState.lose;
        }
    }
}
