using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostSpray : MonoBehaviour
{
    [SerializeField] ParticleSystem sprayParticles;
    [SerializeField] Transform aimTrnasform;

    bool isFireing;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isFireing = true;
            sprayParticles.Play();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isFireing = false;
            sprayParticles.Stop();
        }

        AimWeapon.Instance.Aim(aimTrnasform);
    }
}
