using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
{

    static private PauseMenu _instance;
    public static PauseMenu Instance { get => _instance; }
    [SerializeField] GameObject pauseMenu;

    bool isPaused = false;
    public bool IsPaused { get => isPaused; }


    void Awake(){
        isPaused = pauseMenu.active;
        if(_instance == null){
            _instance = this;
        }else{
            Debug.LogError("Es kann nur einen geben (Menu)");
            Destroy(this);
        }

        if(isPaused){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }
    
    public void Pause(){
        isPaused = !isPaused;
        if(IsPaused) Time.timeScale = 0;
        else Time.timeScale = 1;

        pauseMenu.SetActive(isPaused);
    }

    void Update(){
        if(Input.GetButtonDown("Cancel")){
            Pause();
        }
    }
  
  
}
