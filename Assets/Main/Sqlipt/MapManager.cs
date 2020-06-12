using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    //マップ
    //place
    public GameObject Camera = null;
    public GameObject Coast1 = null;
    public GameObject Coast2 = null;
    public GameObject Coast3 = null;
    public GameObject River = null;
    public GameObject Boat = null;
    public GameObject Lake = null;
    //地方
    public GameObject B = null;
    public GameObject C = null;
    public GameObject D = null;
    public GameObject E = null;
    public GameObject F = null;
    public GameObject G = null;
    public GameObject H = null;

    Vector3 C_pos ;
    Vector3 Coast1_pos ;
    Vector3 Coast2_pos ;
    Vector3 Coast3_pos ;
    Vector3 River_pos ;
    Vector3 Boat_pos ;
    Vector3 Lake_pos ;
    public string stage = "";

//アイテム
    public GameObject point = null;
    public GameObject feed = null;
    public GameObject Mission = null;
    public int point_num = 0;
    public int feed_num = 0;
    public int place = 0;
    public string mission = " ";
    public int mission_num = 0;
    public int target_num = 0;

    [SerializeField] 
    private SoundManager soundmanager = null;
    // Start is called before the first frame update
    void Start()
    {
        //マップ
        C_pos = Camera.transform.position;
        Coast1_pos = Coast1.transform.position;
        Coast2_pos = Coast2.transform.position;
        Coast3_pos = Coast3.transform.position;
        River_pos = River.transform.position;
        Boat_pos = Boat.transform.position;
        Lake_pos = Lake.transform.position;

        stage = PlayerPrefs.GetString("STAGE","A");
        place = PlayerPrefs.GetInt("PLACE",0);

//アイテム
//ポイントとエサをDBから入力
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

        

//アイテム
//画面に反映
        Text P_text = point.GetComponent<Text> ();
        P_text.text = point_num + "p";
        Text F_text = feed.GetComponent<Text> ();
        F_text.text = feed_num.ToString();
        Text M_text = Mission.GetComponent<Text>();
        M_text.text = "ミッション：" + mission + "匹 現在" + target_num + "匹";

        
    }
    public void MoveA(){
         //sound
        soundmanager.Button();
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
    public void MoveB(){
         //sound
        soundmanager.Button();
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
    public void MoveC(){
         //sound
        soundmanager.Button();
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
    public void MoveD(){
         //sound
        soundmanager.Button();
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
    public void MoveE(){
         //sound
        soundmanager.Button();
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
    public void MoveF(){
         //sound
        soundmanager.Button();
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
    public void MoveG(){
         //sound
        soundmanager.Button();
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
    public void MoveH(){
         //sound
        soundmanager.Button();
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
    public void MoveCoast(){
         //sound
        soundmanager.Button();
        place = 1;
        SceneManager.LoadScene("Coast fishing");
    }
    public void MoveCoast1(){
         //sound
        soundmanager.Button();
        place = 2;
        SceneManager.LoadScene("Coast fishing 1");
    }
    public void MoveCoast2(){
         //sound
        soundmanager.Button();
        place = 3;
        SceneManager.LoadScene("Coast fishing 2");
    }
    public void MoveRiver(){
         //sound
        soundmanager.Button();
        place = 0;
        SceneManager.LoadScene("River fishing");
    }
    public void MoveLake(){
         //sound
        soundmanager.Button();
        place = 4;
        SceneManager.LoadScene("Lake fishing");
    }
    public void MoveBoat(){
         //sound
        soundmanager.Button();
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
