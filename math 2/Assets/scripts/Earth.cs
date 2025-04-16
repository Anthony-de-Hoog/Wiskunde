using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    float t = 0;

    private float R = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(R*Mathf.Cos(t), 0, R*Mathf.Sin(t));
        transform.Rotate(0,-100f,0);
        
        t += Time.deltaTime;
    }
}
