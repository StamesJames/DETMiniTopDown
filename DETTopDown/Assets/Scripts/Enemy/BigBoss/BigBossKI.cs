using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BigBossKI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PrefabPooler[] shots;
    [SerializeField] Transform[] circleSpawns;
    [SerializeField] Transform[] rotatingSpawns;
    [SerializeField] float inAllDirectionsRate;
    [SerializeField] float rotatingShotStreamRate;
    [SerializeField] float rotatingFourDirektionsRate;
    [SerializeField] float alternatingFourDirektionsRate;

    [Header("state Change Stuff")]
    [SerializeField] float stateChangeRate;
    [SerializeField] float stateChangeRateRandomRange;

    [Header("Movement Stuff")]
    [SerializeField] Transform[] movePositions;
    [SerializeField] float moveTransformChangeRate;
    [SerializeField] float moveTransformChangeRateRandomRange;

    delegate void BigBossState();

    BigBossState currentStateUpdate;

    AIDestinationSetter setter;

    float nextShotInShootInAllDirections = 0;
    float nextShotRotatingShottream = 0;
    float nextShotInRotatingFourDirections = 0;
    float nextShotInAlternatingFourDirections = 0;
    bool shraeg = false;

    float nextStateIn = 5;

    float nextMoveTransformIn = 0;

    private void Awake()
    {
        setter = GetComponent<AIDestinationSetter>();
        currentStateUpdate = GetRandomNewState();
    }

    private void Update()
    {
        currentStateUpdate?.Invoke();
        checkForMoveTransformChange();
    }

    public void aktivate()
    {

    }


    void ShootInAllDirectionsUpdate()
    {
        if (nextShotInShootInAllDirections <= 0)
        {
            foreach (Transform transform in circleSpawns)
            {
                shots[0].GetObject(transform);
            }
            nextShotInShootInAllDirections = inAllDirectionsRate;
        }
        else if (nextShotInShootInAllDirections > 0)
        {
            nextShotInShootInAllDirections -= Time.deltaTime;
        }
        checkForStateChange();
    }


    void rotatingShotStreamUpdate()
    {
        if (nextShotRotatingShottream <= 0)
        {
            shots[0].GetObject(rotatingSpawns[(int) Directions.RIGHT]);
            nextShotRotatingShottream = rotatingShotStreamRate;
        }
        else if (nextShotRotatingShottream > 0)
        {
            nextShotRotatingShottream -= Time.deltaTime;
        }
        checkForStateChange();

    }

    void rotatingShotFourDirectonsUpdate()
    {
        if (nextShotInRotatingFourDirections <= 0)
        {
            shots[0].GetObject(rotatingSpawns[(int)Directions.RIGHT]);
            shots[0].GetObject(rotatingSpawns[(int)Directions.UP]);
            shots[0].GetObject(rotatingSpawns[(int)Directions.LEFT]);
            shots[0].GetObject(rotatingSpawns[(int)Directions.DOWN]);

            nextShotInRotatingFourDirections = rotatingFourDirektionsRate;
        }
        else if (nextShotInRotatingFourDirections > 0)
        {
            nextShotInRotatingFourDirections -= Time.deltaTime;
        }
        checkForStateChange();

    }

    void alternatingFourDirektionsUpdate()
    {
        if (nextShotInAlternatingFourDirections <= 0)
        {
            if (shraeg)
            {
                shots[0].GetObject(circleSpawns[(int)Directions.RIGHTUP]);
                shots[0].GetObject(circleSpawns[(int)Directions.LEFTUP]);
                shots[0].GetObject(circleSpawns[(int)Directions.LEFTDOWN]);
                shots[0].GetObject(circleSpawns[(int)Directions.RIGHTDOWN]);
            }
            else
            {
                shots[0].GetObject(circleSpawns[(int)Directions.RIGHT]);
                shots[0].GetObject(circleSpawns[(int)Directions.UP]);
                shots[0].GetObject(circleSpawns[(int)Directions.LEFT]);
                shots[0].GetObject(circleSpawns[(int)Directions.DOWN]);
            }
            shraeg = !shraeg;
            nextShotInAlternatingFourDirections = alternatingFourDirektionsRate;
        }
        else if (nextShotInAlternatingFourDirections > 0)
        {
            nextShotInAlternatingFourDirections -= Time.deltaTime;
        }
        checkForStateChange();

    }

    void checkForStateChange()
    {
        if (nextStateIn <= 0)
        {
            currentStateUpdate = GetRandomNewState();
            nextStateIn = stateChangeRate + Random.Range(-stateChangeRateRandomRange, stateChangeRateRandomRange);
        }
        else if (nextStateIn >0 )
        {
            nextStateIn -= Time.deltaTime;
        }
    }

    BigBossState GetRandomNewState()
    {
        int randomNumber = Random.Range(0, 4);
        if (randomNumber == 0)
        {
            return ShootInAllDirectionsUpdate;
        }
        else if (randomNumber == 1)
        {
            return rotatingShotStreamUpdate;
        }
        else if (randomNumber == 2)
        {
            return rotatingShotFourDirectonsUpdate;
        }
        else if (randomNumber == 3)
        {
            return alternatingFourDirektionsUpdate;
        }
        else
        {
            return alternatingFourDirektionsUpdate;
        }
    }

    void checkForMoveTransformChange()
    {
        if (nextMoveTransformIn <= 0)
        {
            setter.target = movePositions[Random.Range(0, movePositions.Length)];
            nextMoveTransformIn = moveTransformChangeRate + Random.Range(-moveTransformChangeRateRandomRange, moveTransformChangeRateRandomRange);
        }
        else if (nextMoveTransformIn > 0)
        {
            nextMoveTransformIn -= Time.deltaTime;
        }

    }

    enum Directions
    {
        RIGHT = 0, RIGHTUP = 1, UP = 2, LEFTUP = 3, LEFT = 4, LEFTDOWN = 5, DOWN = 6, RIGHTDOWN = 7
    }
}

