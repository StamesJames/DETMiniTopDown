using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilCameraShake : MonoBehaviour
{

    static RecoilCameraShake _instance;

    public static RecoilCameraShake Instance { get => _instance; }

    private void Awake()
    {

        if (Instance)
        {
            Debug.LogError("mehr als ein recoil shaker");
        }
        else
        {
            _instance = this;    
        }
    }
    
    void RecoilShake(Vector2 direction, float amplitude, float time)
    {
        
    }

}
