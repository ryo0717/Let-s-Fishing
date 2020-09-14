//マップの処理を管理するプログラム
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    //place
    //カメラ
    public GameObject cam = null;
    //海岸1
    public GameObject coast_first = null;
    //海岸2
    public GameObject coast_second = null;
    //海岸3
    public GameObject coast_third = null;
    //川
    public GameObject river = null;
    //船
    public GameObject boat = null;
    //湖
    public GameObject lake = null;

    //地方canvas
    public GameObject place_parent = null;

    //地方
    public GameObject chugoku_sikoku = null;
    public GameObject kinki = null;
    public GameObject chubu = null;
    public GameObject kanto = null;
    public GameObject tohoku = null;
    public GameObject okinawa = null;
    public GameObject hokkaido = null;

    //現在のStage数
    public string stage = "";

    //プレイヤーポイント数
    public GameObject point = null;
    //プレイヤー餌数
    public GameObject feed = null;
    //プレイヤーミッション数
    public GameObject mission = null;
    public int point_num = 0;
    public int feed_num = 0;
    public int place = 0;
    public string mission_name = " ";
    public int mission_num = 0;
    public int target_num = 0;

    [SerializeField] 
    public SoundManager sound_manager = null;
    void Start()
    {
        //ステージ数の初期化
        stage = PlayerPrefs.GetString("STAGE","A");
        place = PlayerPrefs.GetInt("PLACE",0);

        //ポイントとエサとミッションをDBから入力
        point_num = PlayerPrefs.GetInt("POINT",100);
        feed_num = PlayerPrefs.GetInt("FEED",0);
        mission_name = PlayerPrefs.GetString("MISSION","");
        mission_num = PlayerPrefs.GetInt("MISSION_NUM",1);
        target_num = PlayerPrefs.GetInt("TARGET_NUM",0);
    }

    // Update is called once per frame
    void Update()
    {

        //Playerのミッション数に応じて移動できる場所を解放する

        if(mission_num > 1)
        {
            coast_first.SetActive(true);
            coast_second.SetActive(true);
        }
        if(mission_num > 3)
        {
            coast_third.SetActive(true);
            chugoku_sikoku.SetActive(true);
        }
        if(mission_num > 6)
        {
            lake.SetActive(true);
            kinki.SetActive(true);
        }
        if(mission_num > 9)
        {
            chubu.SetActive(true);
        }
        if(mission_num > 11)
        {
            boat.SetActive(true);
            kanto.SetActive(true);
        }
        if(mission_num > 13)
        {
            tohoku.SetActive(true);
        }
        if(mission_num > 15)
        {
            okinawa.SetActive(true);
        }
        if(mission_num > 17)
        {
            hokkaido.SetActive(true);
        }

        

//画面に反映
        Text p_text = point.GetComponent<Text> ();
        p_text.text = point_num + "p";
        Text f_text = feed.GetComponent<Text> ();
        f_text.text = feed_num.ToString();
        Text m_text = mission.GetComponent<Text>();
        m_text.text = "ミッション：" + mission_name + "匹 現在" + target_num + "匹";

        
    }
    //地方ごとの表示処理

    //九州地方の場合
    public void Move_kyushu()
    {
         //sound
        sound_manager.Button();
        stage = "A";
        cam.transform.localPosition = new Vector3(-78f, -78f, -37f);
        coast_first.transform.localPosition = new Vector3(188f, 180f, 0f);
        coast_second.transform.localPosition = new Vector3(-35f, 50f, 0f);
        coast_third.transform.localPosition = new Vector3(500f, 500f, 0f);
        river.transform.localPosition = new Vector3(103f, -57f, 0f);
        boat.transform.localPosition = new Vector3(500f, 500f, 0f);
        lake.transform.localPosition = new Vector3(500f, 500f, 0f);
    }
    //中国・四国地方の場合
    public void Move_chugoku_sikoku()
    {
         //sound
        sound_manager.Button();
        stage = "B";
        cam.transform.localPosition = new Vector3(-55f, -57f, -37f);
        coast_first.transform.localPosition = new Vector3(160f, 184f, 0f);
        coast_second.transform.localPosition = new Vector3(24f, 18f, 0f);
        coast_third.transform.localPosition = new Vector3(214f, -126f ,0f);
        river.transform.localPosition = new Vector3(500f, 500f, 0f);
        boat.transform.localPosition = new Vector3(500f, 500f, 0f);
        lake.transform.localPosition = new Vector3(500f, 500f, 0f);
    }
    //近畿地方の場合
    public void Move_kinki()
    {
         //sound
        sound_manager.Button();
        stage = "C";
        cam.transform.localPosition = new Vector3(-25f, -47f, -37f);
        coast_first.transform.localPosition = new Vector3(180f, -150f, 0f);
        coast_second.transform.localPosition = new Vector3(500f, 500f, 0f);
        coast_third.transform.localPosition = new Vector3(500f, 500f, 0f);
        river.transform.localPosition = new Vector3(500f, 500f, 0f);
        boat.transform.localPosition = new Vector3(500f, 500f, 0f);
        lake.transform.localPosition = new Vector3(100f, 50f, 0f);
    }
    //中部地方の場合
    public void Move_chubu()
    {
         //sound
        sound_manager.Button();
        stage = "D";
        cam.transform.localPosition = new Vector3(-6f, -34f, -37f);
        coast_first.transform.localPosition = new Vector3(90f, 180f, 0f);
        coast_second.transform.localPosition = new Vector3(500f, 500f, 0f);
        coast_third.transform.localPosition = new Vector3(500f, 500f, 0f);
        river.transform.localPosition = new Vector3(10f, -50f, 0f);
        boat.transform.localPosition = new Vector3(500f, 500f, 0f);
        lake.transform.localPosition = new Vector3(500f, 500f, 0f);
    }
    //関東地方の場合
    public void Move_kanto()
    {
         //sound
        sound_manager.Button();
        stage = "E";
        cam.transform.localPosition = new Vector3(12f, -33f, -37); 
        coast_first.transform.localPosition = new Vector3(250f, 30f, 0f);
        coast_second.transform.localPosition = new Vector3(500f, 500f, 0f);
        coast_third.transform.localPosition = new Vector3(500f, 500f, 0f);
        river.transform.localPosition = new Vector3(500f, 500f, 0f);
        boat.transform.localPosition = new Vector3(140f, -140f, 0f);
        lake.transform.localPosition = new Vector3(500f, 500f, 0f);
    }
    //東北地方の場合
    public void Move_tohoku()
    {
         //sound
        sound_manager.Button();
        stage = "F";
        cam.transform.localPosition = new Vector3(28f, 14f, -37f);
        coast_first.transform.localPosition = new Vector3(-35f, 50f, 0f);
        coast_second.transform.localPosition = new Vector3(500f, 500f, 0f);
        coast_third.transform.localPosition = new Vector3(500f, 500f, 0f);
        river.transform.localPosition = new Vector3(120f, -35f, 0f);
        boat.transform.localPosition = new Vector3(500f, 500f, 0f);
        lake.transform.localPosition = new Vector3(500f, 500f, 0f);
    }
    //沖縄地方の場合
    public void Move_okinawa()
    {
         //sound
        sound_manager.Button();
        stage = "G";
        cam.transform.localPosition = new Vector3(-25f, -89f, -37f);
        coast_first.transform.localPosition = new Vector3(0f, 0f, 0f);
        coast_second.transform.localPosition = new Vector3(500f, 500f, 0f);
        coast_third.transform.localPosition = new Vector3(500f, 500f, 0f);
        river.transform.localPosition = new Vector3(500f, 500f, 0f);
        boat.transform.localPosition = new Vector3(500f, 500f, 0f);
        lake.transform.localPosition = new Vector3(500f, 500f, 0f);
    }
    //北海道地方の場合
    public void Move_hokkaido()
    {
         //sound
        sound_manager.Button();
        stage = "H";
        cam.transform.localPosition = new Vector3(49f, 75f, -47f);
        coast_first.transform.localPosition = new Vector3(180f, 50f, 0f);
        coast_second.transform.localPosition = new Vector3(500f, 500f, 0f);
        coast_third.transform.localPosition = new Vector3(500f, 500f, 0f);
        river.transform.localPosition = new Vector3(50f, -50f, 0f);
        boat.transform.localPosition = new Vector3(150f, -200f, 0f);
        lake.transform.localPosition = new Vector3(500f, 500f, 0f);
    }

    //画面遷移
    //海岸に移動
    public void MoveCoastFirst(){
         //sound
        sound_manager.Button();
        place = 1;
        SceneManager.LoadScene("Coast first fishing");
    }
    public void MoveCoastSecond(){
         //sound
        sound_manager.Button();
        place = 2;
        SceneManager.LoadScene("Coast second fishing");
    }
    public void MoveCoastThird(){
         //sound
        sound_manager.Button();
        place = 3;
        SceneManager.LoadScene("Coast third fishing");
    }
    //川に移動
    public void MoveRiver(){
         //sound
        sound_manager.Button();
        place = 0;
        SceneManager.LoadScene("River fishing");
    }
    //湖に移動
    public void MoveLake(){
         //sound
        sound_manager.Button();
        place = 4;
        SceneManager.LoadScene("Lake fishing");
    }
    //船に移動
    public void MoveBoat(){
         //sound
        sound_manager.Button();
        place = 5;
        SceneManager.LoadScene("Boat fishing");
    }
    void OnDestroy(){
        // ポイントとえさの数を保存
        PlayerPrefs.SetString ("STAGE", stage);
        PlayerPrefs.SetInt ("POINT", point_num);
        PlayerPrefs.SetInt ("FEED", feed_num);
        PlayerPrefs.SetInt ("PLACE", place);
        PlayerPrefs.SetString("MISSION",mission_name);
        PlayerPrefs.SetInt("TARGET_NUM",target_num);
        PlayerPrefs.Save ();
    }
}
