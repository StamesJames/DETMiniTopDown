using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : TriggerEffect
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer renderer;

    int currentSprite = 0;
    OnHitTrigger exitTrigger;

    private new void OnEnable()
    {
        base.OnEnable();
        exitTrigger = GetComponent<OnHitTrigger>();
        exitTrigger.OnExit += Trigger;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        exitTrigger.OnExit -= Trigger;
    }

    protected override void Trigger()
    {
        renderer.sprite = sprites[(++currentSprite) % sprites.Length];
    }

}
