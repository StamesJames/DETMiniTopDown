using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySOBs/ObjectPooler")]
public class PrefabPooler : ScriptableObject
{

    [SerializeField] GameObject pooledObject;

    Queue<GameObject> objects = new Queue<GameObject>();


    public GameObject GetObject(Transform targetTransform)
    {
        GameObject returnObject = null;
        while (returnObject == null)
        {

            if (objects.Count == 0)
            {
                returnObject = Instantiate(pooledObject, targetTransform.position, targetTransform.rotation);
            }
            else
            {
                returnObject = objects.Dequeue();
            }
        }
        returnObject.transform.SetParent(null);
        returnObject.transform.position = targetTransform.position;
        returnObject.transform.rotation = targetTransform.rotation;
        returnObject.SetActive(true);
        return returnObject;
    }

    public GameObject GetPrefab()
    {
        return pooledObject;
    }

    public GameObject GetObject(Transform targetTransform, Transform targetParent)
    {
        GameObject returnObject = null;
        while(returnObject == null)
        {

            if (objects.Count == 0)
            {
                returnObject = Instantiate(pooledObject, targetTransform.position, targetTransform.rotation);
            }
            else
            {
                returnObject = objects.Dequeue();
            }
        }
        returnObject.transform.SetParent(targetParent);
        returnObject.transform.position = targetTransform.position;
        returnObject.transform.rotation = targetTransform.rotation;
        returnObject.SetActive(true);
        return returnObject;
    }

    public GameObject GetObject(Vector2 targetPosition, Transform targetParent)
    {
        GameObject returnObject = null;
        while(returnObject == null)
        {

            if (objects.Count == 0)
            {
                returnObject = Instantiate(pooledObject, targetPosition, Quaternion.identity);
            }
            else
            {
                returnObject = objects.Dequeue();
            }
        }
        returnObject.transform.SetParent(targetParent);
        returnObject.transform.position = targetPosition;
        returnObject.transform.rotation = Quaternion.identity;
        returnObject.SetActive(true);
        return returnObject;
    }

    public void PoolObject(GameObject targetObject)
    {
        targetObject.SetActive(false);
        targetObject.transform.SetParent(null);
        targetObject.transform.position = Vector3.zero;
        targetObject.transform.rotation = Quaternion.identity;
        objects.Enqueue(targetObject);
    }

}
