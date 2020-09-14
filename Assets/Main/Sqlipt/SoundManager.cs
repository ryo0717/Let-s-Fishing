//Soundを管理するプログラム
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
    
    //Bottonが押された時のSound
    public void Button(){
        audioSource.PlayOneShot(button);
    }
    //Shopで購入した時のSound
    public void Buy(){
        audioSource.PlayOneShot(buy);
    }
    //釣り竿を投げた時のSound
    public void Rod(){
        audioSource.PlayOneShot(throw_rod);
    }
    //浮きが着水した時のSound
    public void Float(){
        audioSource.PlayOneShot(drop_float);
    }
    //魚が釣れた時のSound
    public void Success(){
        audioSource.PlayOneShot(fished_success);
    }
    //魚が釣れなかった時のSound
    public void Failure(){
        audioSource.PlayOneShot(fished_failure);
    }
}
