using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    //Sound
    public AudioClip buy;
    public AudioClip button;
    public AudioClip throw_rod;
    public AudioClip drop_float;
    public AudioClip fished_success;
    public AudioClip fished_failure;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //SoundComponent所得
        audioSource = GetComponent<AudioSource>();
        //画面遷移してもオブジェクトが壊れないようにする
        DontDestroyOnLoad (this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Button(){
        audioSource.PlayOneShot(button);
    }
    public void Buy(){
        audioSource.PlayOneShot(buy);
    }
    public void Rod(){
        audioSource.PlayOneShot(throw_rod);
    }
    public void Float(){
        audioSource.PlayOneShot(drop_float);
    }
    public void Success(){
        audioSource.PlayOneShot(fished_success);
    }
    public void Failure(){
        audioSource.PlayOneShot(fished_failure);
    }
}
