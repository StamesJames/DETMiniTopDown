using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour
{
    [SerializeField] GameObject whatToSpawn;

    RoomEnterExitListener roomListener;
    AIController controller;
    Enemy enemyComponent;

    private void Awake()
    {
        controller = GetComponent<AIController>();
        roomListener = GetComponent<RoomEnterExitListener>();
        enemyComponent = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        if (enemyComponent)
        {
            enemyComponent.onMyDeath += SpawnIt;
        }      
    }

    private void OnDisable()
    {
        if (enemyComponent)
        {
            enemyComponent.onMyDeath -= SpawnIt;
        }
    }

    private void SpawnIt(EnemyInformations enemyInfos)
    {
        GameObject  newEnemy =  Instantiate(whatToSpawn, transform.position, Quaternion.identity);
        AIController newController = newEnemy.GetComponent<AIController>();
        RoomEnterExitListener newListener = newEnemy.GetComponent<RoomEnterExitListener>();
        newListener.RoomToListenTo = roomListener.RoomToListenTo;
        if (controller.CurrentTarget != null)
        {
            newController.SetTarget(controller.CurrentTarget);
            newController.Trigger(0);
            newController.Trigger(2);
        }
        newEnemy.SetActive(true);
    }
}
