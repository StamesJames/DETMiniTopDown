using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameManager : MonoBehaviour
{
    CountContainer enemyKilledCounter = new CountContainer();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    void CountEnemyDeath(string enemyName)
    {
        enemyKilledCounter.increaseValue(enemyName);
        SaveEnemyKillCount();
    }

    private void OnEnable()
    {
        Enemy.onEnemyDeath += CountEnemyDeath;
    }

    private void OnDisable()
    {
        Enemy.onEnemyDeath -= CountEnemyDeath;

    }

    public void SaveEnemyKillCount() {
        XmlSerializer serializer = new XmlSerializer(typeof(List<KeyValuePair<string, int>>));
        Directory.CreateDirectory(Application.dataPath + "/SaveFiles/XML/");
        FileStream stream = new FileStream(Application.dataPath + "/SaveFiles/XML/saveFile.xml", FileMode.Create);
        serializer.Serialize(stream, enemyKilledCounter.ToList());
        stream.Close();
    }
}
