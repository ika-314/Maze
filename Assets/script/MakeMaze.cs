using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*

   `  -MMMMMMMF MMMMMMMMMMMMMMMMMMMMNNg,   `  `
      -MMMMMMMF MMMMMMMMMMMMMMMMMMMMMMMMM&
   `  -MNMNNMNF MMMMMMMMMMMMMMMMMMMMMMMMMMb     `
 `    -MMNMMNMF MMMMMMMMMMMMMMMMMMMMMMMMMMM[ `
      -MMMMMMNF ?777777777MMMMMMMN777777777'
   `  -MNNMNMMF jttttttt_.MMMMMMMN, ggggggg]  `
      -MMMNMNMF zttttttt_.MMMMMMMN ,@g@g@@@]
   `  -MNMMMNMF zttttttt_.MMMMMMMN -@@g@g@g]    `
      -MMNMNMMF zttttttt_.MMMMMMMN ,g@@g@@@]  `
 `  ` -MNMMNMMF _~~~~~~~ .MMMMMMMN -@g@@g@@]
   `  -MMNMMNMF jttttttt_.MMMMMMMN -g@g@gg@]   `
      -MNMMNMMF zttttttt_.MMMMMMMN -@g@@@g@]  `
   `  -MMNMMNMF zttttttt_.MMMMMMMN -@g@g@@g]
 `    -MNMMNMMF zttttrtt_.MMMMMMMN -g@g@g@@]    `
    ` -MMNMMNMF zttrtttt_.MMMMMMMN -@g@@g@@]  `
      -MNMMNMMF zttttttt_.MMMMMMMN -@g@g@g@]
 `  ` -MMNMMNMF zttttttt_.MMMMMMMN -ggggggg]  `
      -MNMMNMMb...........MMMMMMMN .........    `
   `  ,MMNMMNMMMMNMMMMNM}.MMMMMMMN -@@@@@@@]
    `  WMMNMMNMNMMNMMNMM}.MMMMMMMN -@@@@@@@] `  `
 `      7MMNMMNMMNMMNMMM}.MMMMMMMN -@@@@@@@]
   `  `   ?"MMMMMNMMMNMM}.MMMMMMMN -@@@@@@@]  `

     */

// 穴掘り法

public class MakeMaze : MonoBehaviour
{
    public enum MazeDataEnum : int
    {
        WALL = 0,
        ROAD = 1,
    }

    [Header("Maze Size")]
    [Range(5, 101)]
    [SerializeField] int m_width = 18;
    [Range(5, 101)]
    [SerializeField] int m_height = 18;

    [Header("Test Map Object")]
    [SerializeField] List<GameObject> m_wall_deco_object = new List<GameObject>();
    [SerializeField] GameObject m_road_object = null;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject Goal;
    [SerializeField] GameObject player;
    [SerializeField] GameObject random;
    [SerializeField] GameObject player_object, AI_object, right_object;
 

    public int d = 0;
    public Vector3 startPosition;

    // 迷路データ
    private MazeDataEnum[] m_map; // マップデータ
    private int m_point_num;  // 穴を掘るチェックポイント数

    // up, down, right, left
    private int[] m_x_table = { 0, 0, +2, -2 };
    private int[] m_y_table = { -2, +2, 0, 0 };
    private int idx;

    //タイマーデータ
    public Text timertext,randomtext,AItext,Righttext;
    public float Timer = 0;

    //オブジェクト定義
    GameObject Player = null;
    GameObject goal_object = null;
    GameObject Random_object = null;
    GameObject ai_1 = null;
    GameObject Right = null;

    Rigidbody Player_Rigidbody;

    public float playerSpeed = 10;  //プレイヤースピード

    public static MakeMaze instance;    //関数に外部からアクセス

    int n = 0;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

         m_height = MazeData.Instance.m_height;
         m_width = MazeData.Instance.m_width;
    }
    // Start is called before the first frame update
    void Start()
    {       
        // マップサイズを奇数にする
        if ((m_width % 2) == 0) { ++m_width; }
        if ((m_height % 2) == 0) { ++m_height; }

        // 外周(壁)の分を考慮して，マップを生成
        m_map = new MazeDataEnum[m_width * m_height];
        // 掘るべきポイント数
        m_point_num = ((m_width - 1) / 2) * ((m_height - 1) / 2) - 1;
        // 穴掘り法
        DigMap();

        // マップ生成
        GenerateMap();

        //端っこを定義
        startPosition = MazeData.Instance.startPosition;

        goal_object = Instantiate(Goal, new Vector3(-startPosition.x,-1.0f,-startPosition.z), Quaternion.identity);//ゴールを端っこに配置
        Random_object = Instantiate(random, startPosition, Quaternion.identity);//ランダムくんを設置
        ai_1 = Instantiate(AI_object, startPosition, Quaternion.identity);//AIくんを設置
        Right = Instantiate(right_object, startPosition, Quaternion.identity);//右壁君を設置       

        //3Dの時　カメラ(プレイヤー）を配置
        if (d == 0)
        {
            //fpsController.SetActive(true);
            Camera.SetActive(false);

            player_object.transform.position = startPosition;

        }else if (d != 0)
        {         
            //プレイヤーをゴールの対角線上に配置        
            Player = Instantiate(player,startPosition, Quaternion.identity);
            Camera.SetActive(true);
            //プレイーのrigidbodyを習得
            Player_Rigidbody = Player.GetComponent<Rigidbody>();
        }
        //マウス消す
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        //タイマー
        timer();   
    }

    // 穴掘り法
    private void DigMap()
    {
        int[] rnd_idx = new int[] { 0, 1, 2, 3 };

        // スタック
        Stack<Vector2> stack = new Stack<Vector2>();

        // 座標(奇数)
        int x = (int)UnityEngine.Random.Range(0, m_width / 2) * 2 + 1;
        int y = (int)UnityEngine.Random.Range(0, m_height / 2) * 2 + 1;       

        while (m_point_num > 0)
        {
            // ランダムな方向を決定
            int[] idx = rnd_idx.OrderBy(i => Guid.NewGuid()).ToArray();

            // 掘ったか判定
            bool is_dig = false;

            for (int i = 0; i < 4; ++i)
            {
                // 範囲内を掘れるか
                bool is_ok = CheckRange(x, y, idx[i]);
                // 掘れる
                if (is_ok)
                {
                    int current = y * m_width + x;
                    int next1 = (y + m_y_table[idx[i]] / 2) * m_width + (x + m_x_table[idx[i]] / 2);
                    int next2 = (y + m_y_table[idx[i]]) * m_width + (x + m_x_table[idx[i]]);

                    // 2マス先が掘れるか
                    if (m_map[next2] == MazeDataEnum.WALL)
                    {
                        m_map[current] = MazeDataEnum.ROAD;
                        m_map[next1] = MazeDataEnum.ROAD;
                        m_map[next2] = MazeDataEnum.ROAD;

                        x = x + m_x_table[idx[i]];
                        y = y + m_y_table[idx[i]];

                        stack.Push(new Vector2(x, y));

                        is_dig = true;

                        --m_point_num;

                        break;
                    }
                }
            }

            // 掘れていない場合は，ランダムな位置を選択
            if (!is_dig)
            {
                var vec = stack.Pop();
                x = (int)vec.x;
                y = (int)vec.y;
            }
            if (m_point_num <= 0) { break; }
        }
    }
    // 範囲チェック
    private bool CheckRange(int x, int y, int idx)
    {
        int nx = x + m_x_table[idx];
        if (nx < 0 || nx >= m_width) { return false; }
        int ny = y + m_y_table[idx];
        if (ny < 0 || ny >= m_height) { return false; }

        return true;
    }

    // マップ生成
    private void GenerateMap()
    {
        // 床の中心地
        float x_center = (m_width - 1) / 2.0f;
        float y_center = (m_height - 1) / 2.0f;
        float x = 0;
        float z = 0;
        GameObject game_object = null;
        for (int i = 0; i < (m_height); ++i)
        {
            for (int j = 0; j < (m_width); ++j)
            {
                var idx = i * (m_width) + j;

                
                if (m_map[idx] == MazeDataEnum.WALL)
                {
                    CreateWall(new Vector3(j - x_center, 0.0f, i - y_center));
                }
            }
        }
        
        if (m_height >= 10)
        {
            z = (m_height / 9) + 1;
        }
        else if(m_height < 10)
        {
            z = 1; 
        }
        if(m_width >= 10)
        {
            x = (m_width / 9) + 1;
        }
        else if(m_width < 10)
        {
            x = 1;
        }
        game_object = Instantiate(m_road_object, new Vector3(0, -1, 0), Quaternion.identity);
        game_object.transform.localScale = new Vector3(x, 1, z);
        game_object.transform.parent = this.transform.Find("Roads");

    }
   
     // 壁生成
    private void CreateWall(Vector3 pos)
    {
        GameObject game_object = null;

        game_object = Instantiate(m_wall_deco_object[idx], pos, Quaternion.identity);
        game_object.transform.parent = this.transform.Find("Walls");
    }

    //タイマーストップ
    public void TimerCounter(String the)
    {

        
        Debug.Log(the +  ":" + (Math.Floor(Timer * 10) / 10));
        if (the == "ランダム")
        {
            n++;
            Destroy(Random_object);
        }
        if (the == "AI")
        {
            n++;
            Destroy(ai_1);
        }
        if (the == "Right")
        {
            n++;           
            Destroy(Right);
        }
        if (n == 1)
        {
            randomtext.text = the + ":" + Timer.ToString("F1");
        }else if (n == 2)
        {
            AItext.text = the + ":" + Timer.ToString("F1");
        }
        else if( n == 3)
        {
            Righttext.text = the + ":" + Timer.ToString("F1");
        }
    }

    //タイマー
    private void timer()
    {        
        Timer = Timer + Time.deltaTime;
        timertext.text = "Time:" + Timer.ToString("F1");
    }
}