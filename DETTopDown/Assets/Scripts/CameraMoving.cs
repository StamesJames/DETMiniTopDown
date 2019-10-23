using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
     [SerializeField] Transform followTarget; // Whatever you want the camera locked to
     [SerializeField] Transform cameraObject; // The object to place the camera on
     public float Radius = 4.5f;
     float Dist;
     Vector3 MousePos1, MousePos2, ScreenMouse, MouseOffset;
     public void Update()
     {
         MousePos1 = Input.mousePosition;
         // the below line assumes this script is attached to a camera object
         ScreenMouse = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(MousePos1.x, MousePos1.y, cameraObject.position.z - GetComponent<Camera>().transform.position.z));
         MouseOffset = ScreenMouse - followTarget.position;
         MousePos2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -transform.position.z));
         //Obj.position.y = ((MousePos2.y - Parent.position.y) / 2.0) + Parent.position.y;
         //Obj.position.x = ((MousePos2.x - Parent.position.x) / 2.0) + Parent.position.x;
         cameraObject.position = new Vector3((MousePos2.x - followTarget.position.x) / 5.0f + followTarget.position.x, (MousePos2.y - followTarget.position.y) / 5.0f + followTarget.position.y, cameraObject.position.z);
 
         Dist = Vector2.Distance(new Vector2(cameraObject.position.x, cameraObject.position.y), new Vector2(followTarget.position.x, followTarget.position.y));
         /*
         if (Dist > Radius)
         {
             var norm = MouseOffset.normalized;
             //Obj.position.x = norm.x * Radius + Parent.position.x;
             //Obj.position.y = norm.y * Radius + Parent.position.y;
             cameraObject.position = new Vector3(norm.x * Radius + followTarget.position.x, norm.y * Radius + followTarget.position.y, cameraObject.position.z);
         }
         */
     }
}
