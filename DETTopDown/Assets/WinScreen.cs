using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{

    [SerializeField] GameObject winScreen;
    void OnEnable(){
        BigBossKI.onBigBossDeath += BossDeath;
    }

    void OnDisable(){
        BigBossKI.onBigBossDeath -= BossDeath;
    }

    void BossDeath(){
        winScreen.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instance.GameOver = true;
    }
}
