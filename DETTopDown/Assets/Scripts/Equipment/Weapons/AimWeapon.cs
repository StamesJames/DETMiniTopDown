using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon
{


    Camera cam;

    public AimWeapon()
    {
        cam = Camera.main;
    }

    public void Aim(Transform from)
    {
        Vector2 mousPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookVec = mousPos - (Vector2)from.position;
        float lookAngle = Mathf.Atan2(lookVec.y, lookVec.x) * Mathf.Rad2Deg;

        from.rotation =  Quaternion.Euler(new Vector3(0, 0, lookAngle));
    }

}
