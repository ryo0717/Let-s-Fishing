using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOuit : MonoBehaviour
{
    [SerializeField] 
    private SoundManager soundmanager = null;
    public void OnClick(){
        soundmanager.Button();
        
        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_WEBPLAYER
		Application.OpenURL("http://www.yahoo.co.jp/");
		#else
		Application.Quit();
		#endif
    }
}
