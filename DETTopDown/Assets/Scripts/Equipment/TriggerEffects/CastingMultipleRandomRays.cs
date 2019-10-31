using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingMultipleRandomRays : TriggerEffect
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
    [SerializeField] int count = 1;
    [SerializeField] float randomRange;

    LineRenderer[] lineRendererClones;

    float effectTimer;

    private void Awake()
    {
        lineRendererClones = new LineRenderer[count];
        lineRendererClones[0] = lineRenderer;
        for (int i = 1; i < lineRendererClones.Length; i++)
        {
            lineRendererClones[i] = Instantiate(lineRenderer);
        }
    }


    protected override void Trigger()
    {
        if (piercing)
        {
            foreach (Transform startTransform in startTransforms)
            {
                for (int i = 0; i < count; i++)
                {
                    Vector2 randomDir = RotateVector2.Rotate(startTransform.right, Random.Range(-randomRange, randomRange));
                    RaycastHit2D[] hits = Physics2D.RaycastAll(startTransform.position, randomDir, distance, whatToHit);
                    foreach (RaycastHit2D hit in hits)
                    {
                        foreach (RayCastEffect effect in rayCastEffects)
                        {
                            effect.TriggerEffect(hit);
                        }
                    }
                    if (showLine)
                    {
                        lineRendererClones[i].SetPosition(0, startTransform.position);
                        lineRendererClones[i].SetPosition(1, startTransform.position + (Vector3)randomDir * distance);
                        lineRendererClones[i].enabled = true;
                        effectTimer = lineRenderTime;
                    }
                }
            }
        }
        else
        {
            foreach (Transform startTransform in startTransforms)
            {
                for (int i = 0; i < count; i++)
                {
                    Vector2 randomDir = RotateVector2.Rotate(startTransform.right, Random.Range(-randomRange, randomRange));
                    RaycastHit2D hit = Physics2D.Raycast(startTransform.position, randomDir, distance, whatToHit);
                    if (hit)
                    {
                        foreach (RayCastEffect effect in rayCastEffects)
                        {
                            effect.TriggerEffect(hit);
                        }
                    }
                    if (showLine)
                    {
                        lineRendererClones[i].SetPosition(0, startTransform.position);
                        if (hit)
                        {
                            lineRendererClones[i].SetPosition(1, hit.point);
                        }
                        else
                        {
                            lineRendererClones[i].SetPosition(1, startTransform.position + (Vector3)randomDir * distance);
                        }
                        lineRendererClones[i].enabled = true;
                        effectTimer = lineRenderTime;
                    }
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
                for (int i = 0; i < count; i++)
                {
                    lineRendererClones[i].enabled = false;
                }
            }
        }
    }
}


public class RotateVector2
{

    public static Vector2 Rotate(Vector2 vector, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector2(vector.x * Mathf.Cos(rad) - vector.y * Mathf.Sin(rad), vector.x * Mathf.Sin(rad) + vector.y * Mathf.Cos(rad));
    }
}