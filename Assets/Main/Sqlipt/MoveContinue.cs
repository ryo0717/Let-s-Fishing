using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveContinue : MonoBehaviour
{
    [SerializeField] 
    private SoundManager soundmanager;
    // Start is called before the first frame update
    public void OnClick(){
        soundmanager.Button();
        SceneManager.LoadScene("Shop");
    }
}
