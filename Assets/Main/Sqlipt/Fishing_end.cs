using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fishing_end : MonoBehaviour
{
    public GameObject fishend = null;
    [SerializeField] 
    private SoundManager soundmanager;

    public void MoveTitle(){
        soundmanager.Button();
        SceneManager.LoadScene("Title");
    }
    public void MoveShop(){
        soundmanager.Button();
        SceneManager.LoadScene("Shop");
    }
    public void act_end_No(){
        soundmanager.Button();
        fishend.SetActive(false);
    }
}
