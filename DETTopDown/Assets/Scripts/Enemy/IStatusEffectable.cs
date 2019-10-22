using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatusEffectable
{

    IDamageable GetIDamageable();

    void AddStatusEffect(StatusEffect effect);

    void RemoveStatusEffect(StatusEffect effect);

    void AddOnTick(OnTick onTick);

    void RemoveOnTick(OnTick onTick);
}
