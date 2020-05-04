using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Spin : MonoBehaviour
{
    public float inputToSpinRatio = 10f;

    private Rigidbody2D targetRigidBody;

    [Inject]
    public void Construct(Rigidbody2D targetRigidBody)
    {
        this.targetRigidBody = targetRigidBody;
    }

    private void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var moveX = inputX * this.inputToSpinRatio * Time.deltaTime;
        this.targetRigidBody.AddTorque(-moveX);
    }
}
