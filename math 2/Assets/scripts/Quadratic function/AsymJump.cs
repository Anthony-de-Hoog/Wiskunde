using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsymJump : MonoBehaviour
{
    float g = -10;
    float vbegin = 10f;
    float hbegin = 0f;
    float horizontalSpeed = 5f; // Add a horizontal speed

    Animator animator;
    QuadraticFunction jumpduration;

    enum State
    {
        grounded,
        airborn
    };
    State myState = State.grounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0;
        jumpduration = new QuadraticFunction(g / 2, vbegin, hbegin);

        print(jumpduration);
    }

    void Update()
    {
        if (myState == State.grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myState = State.airborn;
                animator.speed = 1;
                StartCoroutine(Jump());
            }
        }
    }

    IEnumerator Jump()
    {
        float time = 0;
        Vector2 zero = jumpduration.findZero();
        float jumpDuration = zero.x > zero.y ? zero.x : zero.y;

        while (time < jumpDuration)
        {
            float height = jumpduration.Evaluate(time);
            float horizontalPosition = transform.position.x + horizontalSpeed * Time.deltaTime;
            transform.position = new Vector3(horizontalPosition, height, transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }

        myState = State.grounded;
        animator.speed = 0;
    }
}