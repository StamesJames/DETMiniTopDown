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
        LoadEnemyKillCount();
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
        XmlSerializer serializer = new XmlSerializer(typeof(List<CountContainerItem>));
        Directory.CreateDirectory(Application.dataPath + "/SaveFiles/XML/");
        FileStream stream = new FileStream(Application.dataPath + "/SaveFiles/XML/saveFile.xml", FileMode.Create);
        serializer.Serialize(stream, enemyKilledCounter.ToList());
        stream.Close();
    }

    public void LoadEnemyKillCount()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<CountContainerItem>));
        FileStream stream = new FileStream(Application.dataPath + "/SaveFiles/XML/saveFile.xml", FileMode.Open);
        List<CountContainerItem> tempList = serializer.Deserialize(stream) as List<CountContainerItem>;
        enemyKilledCounter = new CountContainer(tempList);

        stream.Close();

    }
}
