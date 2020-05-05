using UnityEngine;
using System.Collections;
 
public class Fadeout : MonoBehaviour {
    public float fadeTime = 1f;
    public GameObject ob;

    private float currentRemainTime;
    private SpriteRenderer spRenderer;
 
    // Use this for initialization
    void Start () {
	currentRemainTime = fadeTime;
	spRenderer = GetComponent<SpriteRenderer>();
    }
 
    // Update is called once per frame
    void Update () {
        Vector3 obPos = ob.transform.position;
        if(obPos.y < -3){ 
	    currentRemainTime -= Time.deltaTime;

	    float alpha = currentRemainTime / fadeTime;
            var color = spRenderer.color;
	    color.a = alpha;
	    spRenderer.color = color;
	}         
     }

}