using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingRay : TriggerEffect
{

    [SerializeField] LayerMask whatToHit;
    [SerializeField] RayCastEffect[] rayCastEffects;
    [SerializeField] Transform[] startTransforms;
    [SerializeField] float distance;
    [SerializeField] bool piercing;
    [Header("Visualisation Stuff")]
    [SerializeField] bool showLine;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float lineRenderTime = 0.2f;

    float effectTimer;

    protected override void Trigger()
    {
        if (piercing)
        {
            foreach (Transform startTransform in startTransforms)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(startTransform.position, startTransform.right, distance, whatToHit);
                foreach (RaycastHit2D hit in hits)
                {
                    foreach (RayCastEffect effect in rayCastEffects)
                    {
                        effect.TriggerEffect(hit);
                    }
                }
                if (showLine)
                {
                    lineRenderer.SetPosition(0, startTransform.position);
                    lineRenderer.SetPosition(1, startTransform.position + startTransform.right * distance);
                    lineRenderer.enabled = true;
                    effectTimer = lineRenderTime;
                }
            }
        }
        else
        {
            foreach (Transform startTransform in startTransforms)
            {
                RaycastHit2D hit = Physics2D.Raycast(startTransform.position, startTransform.right, distance, whatToHit);
                if (hit)
                {
                    foreach (RayCastEffect effect in rayCastEffects)
                    {
                        effect.TriggerEffect(hit);
                    }
                }
                if (showLine)
                {
                    lineRenderer.SetPosition(0, startTransform.position);
                    if (hit)
                    {
                        lineRenderer.SetPosition(1, hit.point);
                    }
                    else
                    {
                        lineRenderer.SetPosition(1, startTransform.position + startTransform.right * distance);
                    }
                    lineRenderer.enabled = true;
                    effectTimer = lineRenderTime;
                }
            }
        }

    }


    private void Update()
    {
        if (showLine)
        {
            if (effectTimer > 0)
            {
                effectTimer -= Time.deltaTime;
            }
            else if (effectTimer <= 0)
            {
                lineRenderer.enabled = false;
            }
        }
    }
}
