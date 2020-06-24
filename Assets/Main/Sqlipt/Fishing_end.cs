//釣りを終了するメニューを管理するプログラム
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fishing_end : MonoBehaviour
{
    public GameObject fishend = null;
    [SerializeField] 
    private SoundManager sound_manager = null;

//タイトルに戻る
    public void MoveTitle(){
        //Soundを流す
        sound_manager.Button();
        //タイトル画面に遷移
        SceneManager.LoadScene("Title");
    }
//ショップに戻る
    public void MoveShop(){
        //Soundを流す
        sound_manager.Button();
        //ショップ画面に遷移
        SceneManager.LoadScene("Shop");
    }
//ゲームに戻る
    public void act_end_No(){
        //Soundを流す
        sound_manager.Button();
        //ゲームメニューを閉じる
        fishend.SetActive(false);
    }
}
