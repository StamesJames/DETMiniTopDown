using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
                collider.transform.position = targetTransform.position;
        }
    }
}
