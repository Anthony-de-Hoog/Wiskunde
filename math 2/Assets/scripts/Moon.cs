using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] Transform Origin;
    private float t = 0;
    private float R = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(R*Mathf.Cos(t) + Origin.position.x, 0, R*Mathf.Sin(t) + Origin.position.z);
        
        t += 6*Time.deltaTime;
    }
}
