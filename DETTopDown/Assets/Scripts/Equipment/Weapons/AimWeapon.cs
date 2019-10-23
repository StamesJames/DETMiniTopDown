using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon
{
    static AimWeapon _instance;
    public static AimWeapon Instance {
        get {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
               _instance = new AimWeapon();
               return _instance;
            }
        }
    }

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

    public void Aim(Transform from, Vector2 to)
    {
        Vector2 lookVec = to - (Vector2)from.position;
        float lookAngle = Mathf.Atan2(lookVec.y, lookVec.x) * Mathf.Rad2Deg;
        from.rotation = Quaternion.Euler(new Vector3(0, 0, lookAngle));
    }

}
