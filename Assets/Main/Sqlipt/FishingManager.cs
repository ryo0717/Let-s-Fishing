//釣りの処理を管理するプログラム
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingManager : MonoBehaviour
{ 
    public GameObject point = null;
    public GameObject feed = null;
    public GameObject mission = null;
    //ポイント数
    public int point_num = 0;
    //餌数
    public int feed_num = 0;
    //ミッション名
    public string mission_name = " ";
    //ミッション数
    public int mission_num = 0;
    //ミッションターゲット数
    public int target_num = 0;
    //ミッションターゲット名
    public string target = " ";
    //場所番号
    public int place = 0;
    //ステージ番号
    public string stage = "";
    //魚を表示する時間
    private int image_time = 0;

    //hitタイミング
    //魚の配列番号
    private int fish_index = 0;
    //釣り時間
    private int hit_time = 0; 
    //魚がいつhitするかの変数
    private int rand_hit = 0;
    //魚がhitしている時間の長さ
    private int hit_range = 0;
    //魚がhitしているか
    private bool is_hit = false;

    //GameObject

    //画面に表示されるHitの文字
    public GameObject hitter = null;
    //釣り竿
    public GameObject rod = null;
    //浮き
    public GameObject flo = null;
    //釣りをするボタン
    public GameObject fishing_btn = null;
    //釣りあげるボタン
    public GameObject no_fishing_btn = null;
    //釣りメニュー
    public GameObject fishend = null;
    //魚の画像object
    public GameObject fish_obj;

    //List
    
    //fish_nameの配列
    List<string> fish_name = new List<string>();
    //魚の獲得pointの配列
    List<int> fish_point = new List<int>();
    //魚の釣れる難易度の配列
    List<int> difficulty = new List<int>();

    //魚の画像
    private Image fish_image;

    //Sound
    [SerializeField] 
    public SoundManager sound_manager = null;

    void Start()
    {

        //ポイントとエサをDBから入力
        point_num = PlayerPrefs.GetInt("POINT",100);
        feed_num = PlayerPrefs.GetInt("FEED",10);
        place = PlayerPrefs.GetInt("PLACE",0);
        stage = PlayerPrefs.GetString("STAGE","A");
        mission_name = PlayerPrefs.GetString("MISSION","");
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
            fish_name.Add(n);
            fish_point.Add(s);
            difficulty.Add(d);
        }
        fish_image = fish_obj.GetComponent<Image>();
    }

    void Update()
    {
        //画面に反映
        Text p_text = point.GetComponent<Text> ();
        p_text.text = point_num + "p";
        Text f_text = feed.GetComponent<Text> ();
        f_text.text = feed_num.ToString();
        Text m_text = mission.GetComponent<Text>();
        m_text.text = "ミッション：" + mission_name + "匹 現在" + target_num + "匹";

        //釣りをしている間
        if(hit_time > 0){
            //魚がHitした場合
            if(rand_hit > hit_time && rand_hit-hit_range < hit_time){
                //Hit文字を表示
                hitter.SetActive(true);
                //魚がHitしている
                is_hit = true;
            }else{
                //Hit文字を非表示
                hitter.SetActive(false);
                //魚がHitしていない
                is_hit = false;
            }
            //釣り時間経過
            hit_time -= 1;
        }

        //魚の画像表示処理
        if(image_time > 0){
            //魚の画像表示
            fish_obj.SetActive(true);
            //表示時間経過
            image_time -= 1;
        }else{
            //魚の画像非表示
            fish_obj.SetActive(false);
        }
    }
    void OnDestroy(){
        // ポイントとえさの数を保存
        PlayerPrefs.SetInt ("POINT", point_num);
        PlayerPrefs.SetInt ("FEED", feed_num);
        PlayerPrefs.SetString ("STAGE", stage);
        PlayerPrefs.SetString("MISSION",mission_name);
        PlayerPrefs.SetInt ("MISSION_NUM", mission_num);
        PlayerPrefs.SetString("TARGET",target);
        PlayerPrefs.SetInt("TARGET_NUM",target_num);
        PlayerPrefs.Save ();
    }
    public void act_end(){
         //sound
        sound_manager.Button();
        //釣りメニュー表示
        fishend.SetActive(true);
    }
    //釣りをする処理
    public void fishing(){
        
        if(feed_num > 0){
            //sound
            sound_manager.Rod();
            sound_manager.Float();
            //餌を消費
            feed_num -= 1;
            //竿を表示
            rod.SetActive(true);
            //浮きの表示
            flo.SetActive(true);
            //釣りをするボタンの非表示
            fishing_btn.SetActive(false);
            //釣りあげるボタンの表示
            no_fishing_btn.SetActive(true);
            //釣りをする時間の設定
            hit_time = 500;
            //魚がHitするタイミングをランダムで決める
            rand_hit = Random.Range(100,400);
            //どの魚が釣れるかランダムで決める
            fish_index = Random.Range(0, fish_name.Count);
            //魚の画像をセット
            Sprite spr_image = Resources.Load<Sprite>(fish_name[fish_index]);
            fish_image.sprite = spr_image;

            //釣れる難易度の判定
            if(difficulty[fish_index] == 0){
                hit_range = 100;
            }else if(difficulty[fish_index] == 1){
                hit_range = 90;
            }else if(difficulty[fish_index] == 2){
                hit_range = 80;
            }else if(difficulty[fish_index] == 3){
                hit_range = 70;
            }else{
                hit_range = 60;
            }
            
        }
    }
    //釣り上げる処理
    public void no_fishing(){
        //釣れた場合の処理
        if(is_hit){
            //sound
            sound_manager.Success();
            //魚の表示時間の設定
            image_time = 100;
            //ミッションのターゲットであればカウントする
            if(fish_name[fish_index] == target){
                target_num += 1;
            }
            //釣り上げた魚のポイントを獲得
            point_num += fish_point[fish_index];

        //釣れなかった場合の処理
        }else{
            //sound
            sound_manager.Failure();
        }

        //釣りをする時間の初期化
        hit_time = 0;
        //竿の非表示
        rod.SetActive(false);
        //浮きの非表示
        flo.SetActive(false);
        //釣りをするボタンの表示
        fishing_btn.SetActive(true);
        //釣り上げるボタンの非表示
        no_fishing_btn.SetActive(false);
        //Hit文字の非表示
        hitter.SetActive(false);
        
    }
    
}
