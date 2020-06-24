//Continue画面遷移
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveContinue : MonoBehaviour
{
    [SerializeField] 
    private SoundManager sound_manager = null;
    //「Continue」BottonをClickした時の処理
    public void OnClick(){
        //Soundを流す
        sound_manager.Button();
        //Shopへ画面遷移
        SceneManager.LoadScene("Shop");
    }
}
