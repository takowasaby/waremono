using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cup;

    private float cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cupPos = cup.transform.position;

	if(cupPos.y < 1.63f){ 
           transform.position = new Vector3(0, cupPos.y - 1.63f, -10);
	}     
    }
}
