using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticFunction
{
    private float a;
    private float b;
    private float c;

    public QuadraticFunction(float a, float b, float c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public float Evaluate(float t)
    {
        return a * t * t + b * t + c;
    }

    public Vector2 findZero()
    {
        Vector2 isZero = new Vector2();
        float D = (this.b * this.b) - (4 * this.a * this.c);

        if (D < 0)
        {
            // No real roots
            isZero = Vector2.zero;
        }
        else if (D == 0)
        {
            // One real root
            isZero.x = -this.b / (2 * this.a);
            isZero.y = isZero.x;
        }
        else
        {
            // Two real roots
            isZero.x = (-this.b + Mathf.Sqrt(D)) / (2 * this.a);
            isZero.y = (-this.b - Mathf.Sqrt(D)) / (2 * this.a);
        }

        return isZero;
    }
}
