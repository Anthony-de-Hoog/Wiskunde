using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] Body[] _bodies;
    
    Vector3 Force1 = Vector3.zero;
    Vector3 Force2 = Vector3.zero;
    private Vector3 ForceTotal;
    Vector3 acceleration;
    [SerializeField]Vector3 velocity = new Vector3(.1f,-.3f,.2f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Force1 = (_bodies[0].transform.position - transform.position).normalized;
        Force2 = (_bodies[1].transform.position - transform.position).normalized;
        ForceTotal = Force1 + Force2;
        
        acceleration = ForceTotal;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
