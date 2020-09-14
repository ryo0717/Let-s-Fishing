//newgame画面遷移
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNewGame : MonoBehaviour
{
    [SerializeField] 
    public SoundManager sound_manager = null;
    //「NewGame」BottonをClickした時の処理
    public void OnClick(){
        //Soundを流す
        sound_manager.Button();
        //プレイヤーの情報を削除
        PlayerPrefs.DeleteAll();
        //Shopへ画面遷移
        SceneManager.LoadScene("Shop");
    }
}
