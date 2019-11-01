using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpriteChange : TriggerEffect
{

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite pressedSprite;
    [SerializeField] Sprite relesedSprite;

    ButtonTrigger buttonTrigger;

    private new void OnEnable()
    {
        base.OnEnable();
        buttonTrigger = triggerToListen.GetComponent<ButtonTrigger>();
        buttonTrigger.ButtonRelese += Relese;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        buttonTrigger.ButtonRelese -= Relese;
    }

    protected override void Trigger()
    {
        spriteRenderer.sprite = pressedSprite;
    }

    void Relese()
    {
        spriteRenderer.sprite = relesedSprite;
    }
}
