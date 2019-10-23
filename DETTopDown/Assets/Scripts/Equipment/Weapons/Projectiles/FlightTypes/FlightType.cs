using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlightType : MonoBehaviour
{
    [SerializeField] protected float speed;
    public float Speed { get => speed; }
}
