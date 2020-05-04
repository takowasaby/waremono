using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public CircleCollider2D targetCollider;

    private void OnCollisionEnter(Collision _)
    {
        this.targetCollider.enabled = false;
    }
}
