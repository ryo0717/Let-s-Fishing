using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public int point_num = 0;
    public int feed_num = 0;
    public int mission_num = 0;
    // Start is called before the first frame update
    void Start()
    {
        point_num = PlayerPrefs.GetInt("POINT",100);
        feed_num = PlayerPrefs.GetInt("FEED",10);
        mission_num = PlayerPrefs.GetInt("MISSION",0);
    }
    void OnDestroy(){
        // スコアを保存
        PlayerPrefs.SetInt ("POINT", point_num);
        PlayerPrefs.SetInt ("FEED", feed_num);
        PlayerPrefs.SetInt ("MISSION", mission_num);
        PlayerPrefs.Save ();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(point_num);
    }
}
