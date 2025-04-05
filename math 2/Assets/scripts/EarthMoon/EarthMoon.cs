using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMoon : MonoBehaviour
{
    [SerializeField] GameObject Earth, Moon;

    private Vector3 Force, Acceliration, Velocity ;
    
    // Start is called before the first frame update
    void Start()
    {
        Velocity = new Vector3(1.2f,1.3f,3.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Force = (Earth.transform.position - Moon.transform.position).normalized;
        Acceliration = 1 * Force;
        Velocity += Acceliration * Time.deltaTime;
        Moon.transform.position += Velocity * Time.deltaTime;
    }
}
