using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameManager : MonoBehaviour
{
    CountContainer playerGameStats = new CountContainer();

    string saveFilePath;

    static GameManager _instance;
    public static GameManager Instance { get => _instance; }

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.Log("Es wurde ein GameManager zu viel erzeugt");
            Destroy(this);
            return;
        }
        _instance = this;
        PlayerHealth.onPlayerDeath += CountPlayerDeath;
        Enemy.onEnemyDeath += CountEnemyDeath;
        saveFilePath = Application.dataPath + "/SaveFiles/XML/playerGameStatsSaveFile.xml";
        DontDestroyOnLoad(this.gameObject);
        playerGameStats = new CountContainer(saveFilePath);
        StartCoroutine("SaveTime");
    }
    
    void CountPlayerDeath(PlayerInformation information)
    {
        playerGameStats.increaseValue("PLAYER_DEATH");
    }

    void CountEnemyDeath(EnemyInformations enemyInformations)
    {
        playerGameStats.increaseValue(enemyInformations.Name.ToUpper() + "_KILLED");
        playerGameStats.increaseValue("POINTS", enemyInformations.Points);
        playerGameStats.Serialize(saveFilePath);
    }

    IEnumerator SaveTime()
    {
        while (true)
        {
            yield return (new WaitForSeconds(10));
            playerGameStats.increaseValue("SECONDS_PLAYED", 10);
            playerGameStats.Serialize(saveFilePath);
        }
    }

    public int GetPlayerGameStat(string statName)
    {
        return playerGameStats.getInt(statName);
    }

    private void OnDisable()
    {
        Enemy.onEnemyDeath -= CountEnemyDeath;

    }
}
