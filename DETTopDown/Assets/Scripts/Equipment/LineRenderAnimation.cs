using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderAnimation : MonoBehaviour
{
    [SerializeField] Material lineRendererMaterial;
    [SerializeField] float speed;


    private void Update()
    {
        Vector2 oldvalue = lineRendererMaterial.GetTextureOffset("_Offset");
        lineRendererMaterial.SetTextureOffset("_Offset", oldvalue - Vector2.right * speed * Time.deltaTime);
    }
}
