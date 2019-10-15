using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float lifeTime;
    [SerializeField] protected PrefabPooler projectilePool;

    public float Speed { get => speed; set => speed = value; }
    public float LifeTime { get => lifeTime; set => lifeTime = value; }
    public PrefabPooler ProjectilePool { get => projectilePool; set => projectilePool = value; }
}
