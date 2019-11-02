using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOnce : TriggerEffect
{
    [SerializeField] Sprite sprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    bool alreadyTriggered;

    protected override void Trigger()
    {
        if (!alreadyTriggered)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}
