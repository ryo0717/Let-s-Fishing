using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNewGame : MonoBehaviour
{
    [SerializeField] 
    private SoundManager soundmanager;
    public void OnClick(){
        soundmanager.Button();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Shop");
    }
}
