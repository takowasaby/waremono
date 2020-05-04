using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject]
    public void Construct()
    {

    }

    private void Start()
    {
        
    }

    private void Update()
    {
    }

    public Vector2 GetPosition()
    {
        return base.transform.position;
    }
}
