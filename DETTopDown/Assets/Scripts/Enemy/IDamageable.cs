using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void GetDamaged(float dmg, DAMAGETYPE type);

    void GetPushed(Vector2 direction, float force);
}

public enum DAMAGETYPE
{
    NORMAL, MAGIC
}
