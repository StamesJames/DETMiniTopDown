﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void GetDamaged(float dmg, DAMAGETYPE type);

    void GetPushed(Vector2 direction, float force, float stunTime);
}

public enum DAMAGETYPE
{
    NORMAL, PIERCING, PLASMA, FROST, FIRE, ELEKTRIC
}
