//マップの処理を管理するプログラム
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    //place
    //カメラ
    public GameObject Camera = null;
    //海岸1
    public GameObject Coast1 = null;
    //海岸2
    public GameObject Coast2 = null;
    //海岸3
    public GameObject Coast3 = null;
    //川
    public GameObject River = null;
    //船
    public GameObject Boat = null;
    //湖
    public GameObject Lake = null;

    //地方
    public GameObject B = null;
    public GameObject C = null;
    public GameObject D = null;
    public GameObject E = null;
    public GameObject F = null;
    public GameObject G = null;
    public GameObject H = null;

//Position
    Vector3 C_pos ;
    Vector3 Coast1_pos ;
    Vector3 Coast2_pos ;
    Vector3 Coast3_pos ;
    Vector3 River_pos ;
    Vector3 Boat_pos ;
    Vector3 Lake_pos ;
    //現在のStage数
    public string stage = "";

    //プレイヤーポイント数
    public GameObject point = null;
    //プレイヤー餌数
    public GameObject feed = null;
    //プレイヤーミッション数
    public GameObject Mission = null;
    public int point_num = 0;
    public int feed_num = 0;
    public int place = 0;
    public string mission = " ";
    public int mission_num = 0;
    public int target_num = 0;

    [SerializeField] 
    private SoundManager sound_manager = null;
    // Start is called before the first frame update
    void Start()
    {
        //マップPosition
        C_pos = Camera.transform.position;
        Coast1_pos = Coast1.transform.position;
        Coast2_pos = Coast2.transform.position;
        Coast3_pos = Coast3.transform.position;
        River_pos = River.transform.position;
        Boat_pos = Boat.transform.position;
        Lake_pos = Lake.transform.position;

        //ステージ数の初期化
        stage = PlayerPrefs.GetString("STAGE","A");
        place = PlayerPrefs.GetInt("PLACE",0);

        //ポイントとエサとミッションをDBから入力
        point_num = PlayerPrefs.GetInt("POINT",100);
        feed_num = PlayerPrefs.GetInt("FEED",0);
        mission = PlayerPrefs.GetString("MISSION","");
        mission_num = PlayerPrefs.GetInt("MISSION_NUM",1);
        target_num = PlayerPrefs.GetInt("TARGET_NUM",0);
    }

    // Update is called once per frame
    void Update()
    {
        //マップ
        Camera.transform.position = C_pos;
        Coast1.transform.position = Coast1_pos;
        Coast2.transform.position = Coast2_pos;
        Coast3.transform.position = Coast3_pos;
        River.transform.position = River_pos;
        Boat.transform.position = Boat_pos;
        Lake.transform.position = Lake_pos;

        //Playerのミッション数に応じて移動できる場所を解放する

        if(mission_num > 1){
            Coast1.SetActive(true);
            Coast2.SetActive(true);
        }
        if(mission_num > 3){
            Coast3.SetActive(true);
            B.SetActive(true);
        }
        if(mission_num > 6){
            Lake.SetActive(true);
            C.SetActive(true);
        }
        if(mission_num > 9){
            D.SetActive(true);
        }
        if(mission_num > 11){
            Boat.SetActive(true);
            E.SetActive(true);
        }
        if(mission_num > 13){
            F.SetActive(true);
        }
        if(mission_num > 15){
            G.SetActive(true);
        }
        if(mission_num > 17){
            H.SetActive(true);
        }

        

//画面に反映
        Text P_text = point.GetComponent<Text> ();
        P_text.text = point_num + "p";
        Text F_text = feed.GetComponent<Text> ();
        F_text.text = feed_num.ToString();
        Text M_text = Mission.GetComponent<Text>();
        M_text.text = "ミッション：" + mission + "匹 現在" + target_num + "匹";

        
    }
    //地方ごとの表示処理
    //A地方の場合
    public void MoveA(){
         //sound
        sound_manager.Button();
        stage = "A";
        C_pos.x = -78f;
        C_pos.y = -78f;
        C_pos.z = -37f;
        Coast1_pos.x = 188f + 473f;
        Coast1_pos.y = 180f + 295.5f;
        Coast1_pos.z = 0f;
        Coast2_pos.x = -35f + 473f;
        Coast2_pos.y = 50f + 295.5f;
        Coast2_pos.z = 0f;
        Coast3_pos.x = 500f + 473f;
        Coast3_pos.y = 500f + 295.5f;
        Coast3_pos.z = 0f;
        River_pos.x = 103f + 473f;
        River_pos.y = -57f + 295.5f;
        River_pos.z = 0f;
        Boat_pos.x = 500f + 473f;
        Boat_pos.y = 500f + 295.5f;
        Boat_pos.z = 0f;
        Lake_pos.x = 500f + 473f;
        Lake_pos.y = 500f + 295.5f;
        Lake_pos.z = 0f;
    }
    //B地方の場合
    public void MoveB(){
         //sound
        sound_manager.Button();
        stage = "B";
        C_pos.x = -55f;
        C_pos.y = -57f;
        C_pos.z = -37f;
        Coast1_pos.x = 160f + 473f;
        Coast1_pos.y = 255f + 295.5f;
        Coast1_pos.z = 0f;
        Coast2_pos.x = 24f + 473f;
        Coast2_pos.y = 18f + 295.5f;
        Coast2_pos.z = 0f;
        Coast3_pos.x = 255f + 473f;
        Coast3_pos.y = -150f + 295.5f;
        Coast3_pos.z = 0f;
        River_pos.x = 500f + 473f;
        River_pos.y = 500f + 295.5f;
        River_pos.z = 0f;
        Boat_pos.x = 500f + 473f;
        Boat_pos.y = 500f + 295.5f;
        Boat_pos.z = 0f;
        Lake_pos.x = 500f + 473f;
        Lake_pos.y = 500f + 295.5f;
        Lake_pos.z = 0f;
    }
    //C地方の場合
    public void MoveC(){
         //sound
        sound_manager.Button();
        stage = "C";
        C_pos.x = -25f;
        C_pos.y = -47f;
        C_pos.z = -37f;
        Coast1_pos.x = 180f + 473f;
        Coast1_pos.y = -150f + 295.5f;
        Coast1_pos.z = 0f;
        Coast2_pos.x = 500f + 473f;
        Coast2_pos.y = 500f + 295.5f;
        Coast2_pos.z = 0f;
        Coast3_pos.x = 500f + 473f;
        Coast3_pos.y = 500f + 295.5f;
        Coast3_pos.z = 0f;
        River_pos.x = 500f + 473f;
        River_pos.y = 500f + 295.5f;
        River_pos.z = 0f;
        Boat_pos.x = 500f + 473f;
        Boat_pos.y = 500f + 295.5f;
        Boat_pos.z = 0f;
        Lake_pos.x = 100f + 473f;
        Lake_pos.y = 50f + 295.5f;
        Lake_pos.z = 0f;
    }
    //D地方場合
    public void MoveD(){
         //sound
        sound_manager.Button();
        stage = "D";
        C_pos.x = -6f;
        C_pos.y = -34f;
        C_pos.z = -37f;
        Coast1_pos.x = 90f + 473f;
        Coast1_pos.y = 180f + 295.5f;
        Coast1_pos.z = 0f;
        Coast2_pos.x = 500f + 473f;
        Coast2_pos.y = 500f + 295.5f;
        Coast2_pos.z = 0f;
        Coast3_pos.x = 500f + 473f;
        Coast3_pos.y = 500f + 295.5f;
        Coast3_pos.z = 0f;
        River_pos.x = 10f + 473f;
        River_pos.y = -50f + 295.5f;
        River_pos.z = 0f;
        Boat_pos.x = 500f + 473f;
        Boat_pos.y = 500f + 295.5f;
        Boat_pos.z = 0f;
        Lake_pos.x = 500f + 473f;
        Lake_pos.y = 500f + 295.5f;
        Lake_pos.z = 0f;
    }
    //E地方の場合
    public void MoveE(){
         //sound
        sound_manager.Button();
        stage = "E";
        C_pos.x = 12f;
        C_pos.y = -33f;
        C_pos.z = -37f;
        Coast1_pos.x = 250f + 473f;
        Coast1_pos.y = 30f + 295.5f;
        Coast1_pos.z = 0f;
        Coast2_pos.x = 500f + 473f;
        Coast2_pos.y = 500f + 295.5f;
        Coast2_pos.z = 0f;
        Coast3_pos.x = 500f + 473f;
        Coast3_pos.y = 500f + 295.5f;
        Coast3_pos.z = 0f;
        River_pos.x = 500f + 473f;
        River_pos.y = 500f + 295.5f;
        River_pos.z = 0f;
        Boat_pos.x = 140f + 473f;
        Boat_pos.y = -140f + 295.5f;
        Boat_pos.z = 0f;
        Lake_pos.x = 500f + 473f;
        Lake_pos.y = 500f + 295.5f;
        Lake_pos.z = 0f;
    }
    //F地方の場合
    public void MoveF(){
         //sound
        sound_manager.Button();
        stage = "F";
        C_pos.x = 28f;
        C_pos.y = 14f;
        C_pos.z = -37f;
        Coast1_pos.x = -35f + 473f;
        Coast1_pos.y = 50f + 295.5f;
        Coast1_pos.z = 0f;
        Coast2_pos.x = 500f + 473f;
        Coast2_pos.y = 500f + 295.5f;
        Coast2_pos.z = 0f;
        Coast3_pos.x = 500f + 473f;
        Coast3_pos.y = 500f + 295.5f;
        Coast3_pos.z = 0f;
        River_pos.x = 120f + 473f;
        River_pos.y = -35f + 295.5f;
        River_pos.z = 0f;
        Boat_pos.x = 500f + 473f;
        Boat_pos.y = 500f + 295.5f;
        Boat_pos.z = 0f;
        Lake_pos.x = 500f + 473f;
        Lake_pos.y = 500f + 295.5f;
        Lake_pos.z = 0f;
    }
    //G地方の場合
    public void MoveG(){
         //sound
        sound_manager.Button();
        stage = "G";
        C_pos.x = -25f;
        C_pos.y = -89f;
        C_pos.z = -37f;
        Coast1_pos.x = 0f + 473f;
        Coast1_pos.y = 0f + 295.5f;
        Coast1_pos.z = 0f;
        Coast2_pos.x = 500f + 473f;
        Coast2_pos.y = 500f + 295.5f;
        Coast2_pos.z = 0f;
        Coast3_pos.x = 500f + 473f;
        Coast3_pos.y = 500f + 295.5f;
        Coast3_pos.z = 0f;
        River_pos.x = 500f + 473f;
        River_pos.y = 500f + 295.5f;
        River_pos.z = 0f;
        Boat_pos.x = 500f + 473f;
        Boat_pos.y = 500f + 295.5f;
        Boat_pos.z = 0f;
        Lake_pos.x = 500f + 473f;
        Lake_pos.y = 500f + 295.5f;
        Lake_pos.z = 0f;
    }
    //H地方の場合
    public void MoveH(){
         //sound
        sound_manager.Button();
        stage = "H";
        C_pos.x = 49f;
        C_pos.y = 75f;
        C_pos.z = -47f;
        Coast1_pos.x = 180f + 473f;
        Coast1_pos.y = 50f + 295.5f;
        Coast1_pos.z = 0f;
        Coast2_pos.x = 500f + 473f;
        Coast2_pos.y = 500f + 295.5f;
        Coast2_pos.z = 0f;
        Coast3_pos.x = 500f + 473f;
        Coast3_pos.y = 500f + 295.5f;
        Coast3_pos.z = 0f;
        River_pos.x = 50f + 473f;
        River_pos.y = -50f + 295.5f;
        River_pos.z = 0f;
        Boat_pos.x = 150f + 473f;
        Boat_pos.y = -200f + 295.5f;
        Boat_pos.z = 0f;
        Lake_pos.x = 500f + 473f;
        Lake_pos.y = 500f + 295.5f;
        Lake_pos.z = 0f;
    }
    //画面遷移
    //海岸に移動
    public void MoveCoast(){
         //sound
        sound_manager.Button();
        place = 1;
        SceneManager.LoadScene("Coast fishing");
    }
    public void MoveCoast1(){
         //sound
        sound_manager.Button();
        place = 2;
        SceneManager.LoadScene("Coast fishing 1");
    }
    public void MoveCoast2(){
         //sound
        sound_manager.Button();
        place = 3;
        SceneManager.LoadScene("Coast fishing 2");
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
        PlayerPrefs.SetString("MISSION",mission);
        PlayerPrefs.SetInt("TARGET_NUM",target_num);
        PlayerPrefs.Save ();
    }
}
