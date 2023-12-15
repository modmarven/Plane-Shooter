using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFanRotate : MonoBehaviour
{
    private float rotateSpeed = 500.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed);
    }
}
