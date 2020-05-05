﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleFall : MonoBehaviour
{
    public AudioSource audioSource;
    private int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
	if (Input.anyKey) {
	     Invoke("fall",2);
	     flag = 1;
	}
    }

    void fall()
    {
        audioSource.Play();
        var rb = GetComponent<Rigidbody2D>();
         rb.bodyType = RigidbodyType2D.Dynamic;
         rb.AddForce(Vector2.up * 50f);
    }
}
