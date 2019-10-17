﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void GetDamaged(float dmg, DAMAGETYPE type);
}

public enum DAMAGETYPE
{
    NORMAL, MAGIC
}
