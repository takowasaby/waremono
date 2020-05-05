using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour {

    //public
    public float speed = 1.0f;

    //private
    private Text text;
    private float time;
    private int count = -1;

    private enum ObjType{
        TEXT,
    };
    private ObjType thisObjType = ObjType.TEXT;

    void Start() {
            thisObjType = ObjType.TEXT;
            text = this.gameObject.GetComponent<Text>();
    }

    void Update () {
	if (Input.GetKeyDown("d")) {
           speed = 3.0f;
	   count += 1;
        }
        text.color = GetAlphaColor(text.color);

    }


    Color GetAlphaColor(Color color) {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
	if(count >= 0 && color.a <= 0.02f){
	   count += 1;
	}

	if(count >= 3){
	   color.a = 0.0f;
	   return color;
	}
        return color;
    }
}