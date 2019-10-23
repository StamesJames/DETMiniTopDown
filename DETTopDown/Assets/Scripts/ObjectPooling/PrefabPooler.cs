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
        GameObject returnObject;
        if (objects.Count == 0)
        {
            returnObject = Instantiate(pooledObject, targetTransform.position, targetTransform.rotation);
        }
        else
        {
            returnObject = objects.Dequeue();
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
        GameObject returnObject;
        if (objects.Count == 0)
        {
            returnObject = Instantiate(pooledObject, targetTransform.position, targetTransform.rotation);
        }
        else
        {
            returnObject = objects.Dequeue();
        }
        returnObject.transform.SetParent(targetParent);
        returnObject.transform.position = targetTransform.position;
        returnObject.transform.rotation = targetTransform.rotation;
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
