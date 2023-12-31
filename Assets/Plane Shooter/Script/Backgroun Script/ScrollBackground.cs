using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset = offset + new Vector2(0, speed * Time.fixedDeltaTime);
        meshRenderer.material.mainTextureOffset = offset;
    }
}
