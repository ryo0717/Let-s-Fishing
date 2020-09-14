//ゲーム終了処理
using UnityEngine;

public class MoveQuit : MonoBehaviour
{
    [SerializeField] 
    public SoundManager sound_manager = null;
    //「Quit」BottonをClickした時の処理
    public void OnClick(){
        //Soundを流す
        sound_manager.Button();
        //Quit処理
        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
    }
}
