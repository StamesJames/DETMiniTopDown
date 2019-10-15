using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayScene (string scene){
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }

}
