using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySOBs/RayCastEffects/playHitEffect")]
public class PlayHitEffectRayCastEffect : RayCastEffect
{
    [SerializeField] LayerMask whatToHit;

    public override void TriggerEffect(RaycastHit2D hit)
    {
        if (((1 << hit.collider.gameObject.layer) & whatToHit) > 0)
        {
            IEffektGiveable target = hit.collider.gameObject.GetComponent<IEffektGiveable>();

            if (target != null)
            {
                PrefabPooler particleObject = target.GetDamageEffect();
                GameObject newObject = particleObject.GetObject(hit.point, hit.transform);
                newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(hit.normal.y, hit.normal.x) * Mathf.Rad2Deg));
                newObject.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
