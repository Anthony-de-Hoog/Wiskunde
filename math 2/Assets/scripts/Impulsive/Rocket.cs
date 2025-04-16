using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Vector3 velocity = new Vector3(15, 0, 0);
    Vector2 min, max;
    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] sprites;
    enum State
    {
        rest,
        accelerate,
        turnLeft,
        turnRight,
    };

    State myState = State.rest;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        switch (myState)
        {
            case State.rest:
                spriteRenderer.sprite = sprites[0];
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    myState = State.accelerate;
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    myState = State.turnLeft;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    myState = State.turnRight;
                }
                break;

            case State.accelerate:
                spriteRenderer.sprite = sprites[1];
                velocity += transform.right * Time.deltaTime;
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    myState = State.rest;
                }
                break;

            case State.turnLeft:
                spriteRenderer.sprite = sprites[2];
                transform.Rotate(0, 0, 5);
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    myState = State.rest;
                }
                break;

            case State.turnRight:
                spriteRenderer.sprite = sprites[3];
                transform.Rotate(0, 0, -5);
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    myState = State.rest;
                }
                break;
        }

        
        if (transform.position.x > max.x)
        {
            transform.position = new Vector3(min.x, transform.position.y, 0);
        }
        if (transform.position.x < min.x)
        {
            transform.position = new Vector3(max.x, transform.position.y, 0);
        }
        if (transform.position.y > max.y)
        {
            transform.position = new Vector3(transform.position.x, min.y, 0);
        }
        if (transform.position.y < min.y)
        {
            transform.position = new Vector3(transform.position.x, max.y, 0);
        }
    }
}