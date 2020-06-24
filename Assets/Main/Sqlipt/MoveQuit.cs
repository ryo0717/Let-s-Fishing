//ゲーム終了処理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveQuit : MonoBehaviour
{
    [SerializeField] 
    private SoundManager sound_manager = null;
    //「Quit」BottonをClickした時の処理
    public void OnClick(){
        //Soundを流す
        sound_manager.Button();
        //Quit処理
        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_WEBPLAYER
		Application.OpenURL("http://www.yahoo.co.jp/");
		#else
		Application.Quit();
		#endif
    }
}
