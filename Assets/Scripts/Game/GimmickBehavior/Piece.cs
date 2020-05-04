using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public float force = 100f;

    public Rigidbody2D target;

    private void Start()
    {
        var dir = new Vector2(Random.value, Random.value);
        this.target.AddForce(dir * this.force);
        this.target.AddTorque(Random.value * this.force);
    }
}
