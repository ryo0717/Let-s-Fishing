using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingManager : MonoBehaviour
{ 
    public GameObject point = null;
    public GameObject feed = null;
    public GameObject Mission = null;
    public int point_num = 0;
    public int feed_num = 0;
    public string mission = " ";
    public int mission_num = 0;
    public int target_num = 0;
    public string target = " ";
    //場所番号
    public int place = 0;
    //ステージ番号
    public string stage = "";
    private int imagetime = 0;

    //hitタイミング
    private int index = 0;
    private int hittime = 0; 
    private int Rand_hit = 0;
    private int Hit_Range = 0;
    private bool hit = false;

    public GameObject hitter = null;

    //GameObject

    public GameObject rod = null;
    public GameObject flo = null;
    public GameObject fishing_B = null;
    public GameObject no_fishing_B = null;

    public GameObject fishend = null;
    //Image
    private Image f_image;

    public GameObject F_Image;

    List<string> fishname = new List<string>();
    List<int> sell = new List<int>();
    List<int> difficulty = new List<int>();

    //Sound
    [SerializeField] 
    private SoundManager soundmanager = null;

    void Start()
    {
        
        
            // strList.Add("Samurai");
            // strList.Add("Engineer");

        //ポイントとエサをDBから入力
        point_num = PlayerPrefs.GetInt("POINT",100);
        feed_num = PlayerPrefs.GetInt("FEED",10);
        place = PlayerPrefs.GetInt("PLACE",0);
        stage = PlayerPrefs.GetString("STAGE","A");
        mission = PlayerPrefs.GetString("MISSION","");
        mission_num = PlayerPrefs.GetInt("MISSION_NUM",1);
        target = PlayerPrefs.GetString("TARGET","");
        target_num = PlayerPrefs.GetInt("TARGET_NUM",0);


        //DB

        SqliteDatabase sqlDB = new SqliteDatabase("FishGame.db");
        string query = "select Name,Sell,Difficulty from Fish_Mst where " + stage + "=1 and Place = " + place.ToString();
        DataTable dataTable = sqlDB.ExecuteQuery(query);

        string n = "";
        int s = 0;
        int d = 0;
        foreach(DataRow dr in dataTable.Rows){
            n = (string)dr["Name"];
            s = (int)dr["Sell"];
            d = (int)dr["Difficulty"];
            fishname.Add(n);
            sell.Add(s);
            difficulty.Add(d);

            // Debug.Log ("Name:" + fishname + " Sell:" + sell);
        }
        f_image = F_Image.GetComponent<Image>();
    }

    void Update()
    {
        //画面に反映
        Text P_text = point.GetComponent<Text> ();
        P_text.text = point_num + "p";
        Text F_text = feed.GetComponent<Text> ();
        F_text.text = feed_num.ToString();
        Text M_text = Mission.GetComponent<Text>();
        M_text.text = "ミッション：" + mission + "匹 現在" + target_num + "匹";

        //hittime
        if(hittime > 0){
            if(Rand_hit > hittime && Rand_hit-Hit_Range < hittime){
                hitter.SetActive(true);
                hit = true;
            }else{
                hitter.SetActive(false);
                hit = false;
            }
            hittime -= 1;
            //Debug.Log ("hittime:" + hittime + " Rand_hit:" + Rand_hit);
        }

        if(imagetime > 0){
            F_Image.SetActive(true);
            imagetime -= 1;
        }else{
            F_Image.SetActive(false);
        }

        //Debug.Log (target);
    }
    void OnDestroy(){
        // ポイントとえさの数を保存
        PlayerPrefs.SetInt ("POINT", point_num);
        PlayerPrefs.SetInt ("FEED", feed_num);
        PlayerPrefs.SetString ("STAGE", stage);
        PlayerPrefs.SetString("MISSION",mission);
        PlayerPrefs.SetInt ("MISSION_NUM", mission_num);
        PlayerPrefs.SetString("TARGET",target);
        PlayerPrefs.SetInt("TARGET_NUM",target_num);
        PlayerPrefs.Save ();
    }
    public void act_end(){
         //sound
        soundmanager.Button();
        fishend.SetActive(true);
    }
    public void fishing(){
        
        if(feed_num > 0){
            //sound
            soundmanager.Rod();
            soundmanager.Float();
            //feed
            feed_num -= 1;
            rod.SetActive(true);
            flo.SetActive(true);
            fishing_B.SetActive(false);
            no_fishing_B.SetActive(true);
            hittime = 300;
            Rand_hit = Random.Range(30,200);
            index = Random.Range(0, fishname.Count);

            Sprite image = Resources.Load<Sprite>(fishname[index]);
            f_image.sprite = image;



            if(difficulty[index] == 0){
                Hit_Range = 100;
            }else if(difficulty[index] == 1){
                Hit_Range = 100;
            }else if(difficulty[index] == 2){
                Hit_Range = 100;
            }else if(difficulty[index] == 3){
                Hit_Range = 100;
            }else{
                Hit_Range = 5;
            }
            
        }
    }
    public void no_fishing(){
        //釣れた場合のみ
        if(hit == true){
            //sound
            soundmanager.Success();
            imagetime = 100;
            if(fishname[index] == target){
                target_num += 1;
            }
            Debug.Log (fishname[index]);
            point_num += sell[index];
        }else{
            //sound
            soundmanager.Failure();
        }
        hittime = 0;
        rod.SetActive(false);
        flo.SetActive(false);
        fishing_B.SetActive(true);
        no_fishing_B.SetActive(false);
        hitter.SetActive(false);
        
    }
    
}
