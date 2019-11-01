using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : TriggerEffect
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;

    int currentSprite = 0;

    protected override void Trigger()
    {
        spriteRenderer.sprite = sprites[(++currentSprite) % sprites.Length];
    }

}
