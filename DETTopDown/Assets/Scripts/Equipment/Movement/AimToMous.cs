using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToMous : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.Instance.IsPaused)
        {

            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookVec = mousPos - (Vector2)transform.position;
            float lookAngle = Mathf.Atan2(lookVec.y, lookVec.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, lookAngle));
        }
    }
}
