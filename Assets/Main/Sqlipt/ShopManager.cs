//ショップの処理を管理するプログラム
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    //プレイヤーが所持しているポイント数
    public GameObject point = null;
    //プレイヤーが所持している餌数
    public GameObject feed = null;
    //プレイヤーが進行中のミッション
    public GameObject mission = null;

    public int point_num = 0;
    public int feed_num = 0;
    public int mission_num = 0;
    public int target_num = 0;
    public string target = " ";
    public string mission_name = " ";

    [SerializeField] 
    public SoundManager sound_manager = null;

    //ミッション
    int m_num = 0;
    string m_name = "";
    int m_need = 0;
    int m_reward = 0;
    // Start is called before the first frame update
    void Start()
    {
        //ポイントとエサとミッションをDBから入力
        point_num = PlayerPrefs.GetInt("POINT",100);
        feed_num = PlayerPrefs.GetInt("FEED",10);
        mission_name = PlayerPrefs.GetString("MISSION","");
        mission_num = PlayerPrefs.GetInt("MISSION_NUM",1);
        target = PlayerPrefs.GetString("TARGET","");
        target_num = PlayerPrefs.GetInt("TARGET_NUM",0);

        //DB読み込み
        ReadDB();

        //ミッションの切り替え処理
        if(target_num >= m_need){
            point_num += m_reward;
            mission_num += 1;
            target_num = 0;
            ReadDB();
        }
        target = m_name;

        mission_name = m_name + m_need; 
    }

    // Update is called once per frame
    void Update()
    {
        //画面に反映
        Text p_text = point.GetComponent<Text> ();
        p_text.text = point_num + "p";
        Text f_text = feed.GetComponent<Text> ();
        f_text.text = feed_num.ToString();
        Text m_text = mission.GetComponent<Text>();
        m_text.text = "ミッション：" + mission_name + "匹 現在" + target_num + "匹";
        
    }
    //えさの購入
    public void buyfeed(){
        if(point_num >= 5){
            sound_manager.Buy();
            point_num -= 5; 
            feed_num += 1;
        }
    }
    //ルアーの購入（未実装）
    public void buylure(){
        if(point_num >= 150){
            sound_manager.Buy();
            //point_num -= 150; 
        }
    }
    //リールの購入（未実装）
    public void buyreel(){
        if(point_num >= 150){
            sound_manager.Buy();
            //point_num -= 150; 
        }
    }
    //つりざおの購入（未実装）
    public void buyrod(){
        if(point_num >= 200){
            sound_manager.Buy();
            //point_num -= 200;
        }
    }
    void OnDestroy(){
        // ポイントとえさの数を保存
        PlayerPrefs.SetInt ("POINT", point_num);
        PlayerPrefs.SetInt ("FEED", feed_num);
        PlayerPrefs.SetString("MISSION",mission_name);
        PlayerPrefs.SetInt ("MISSION_NUM", mission_num);
        PlayerPrefs.SetString("TARGET",target);
        PlayerPrefs.SetInt("TARGET_NUM",target_num);
        PlayerPrefs.Save ();
    }
    public void MoveMap(){
        sound_manager.Button();
        SceneManager.LoadScene("MapSelect");
    }
    //DBの読み込み
    private void ReadDB(){
        SqliteDatabase sqlDB = new SqliteDatabase("FishGame.db");
        string query = "select * from Mission_Mst where Number = " + mission_num;
        DataTable dataTable = sqlDB.ExecuteQuery(query);

        
        foreach(DataRow dr in dataTable.Rows){
            m_num = (int)dr["Number"];
            m_name = (string)dr["Name"];
            m_need = (int)dr["Need"];
            m_reward = (int)dr["Reward"];
        }
    }
}
