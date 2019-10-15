using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            if(Input.GetButtonDown("Fire2")){
                collider.transform.position = targetTransform.position;
            }
        }
    }
}
