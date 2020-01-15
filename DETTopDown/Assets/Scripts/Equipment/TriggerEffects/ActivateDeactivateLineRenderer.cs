using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivateLineRenderer : PressAndReleasEffect
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Vector2 startPosition;
    [SerializeField] Vector2 endPosition;

    protected override void Releas()
    {
        lineRenderer.gameObject.SetActive(false);
    }

    protected override void Trigger()
    {
        lineRenderer.gameObject.SetActive(true);
    }


    private void Update()
    {
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }

}
