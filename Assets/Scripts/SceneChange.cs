using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneChange : MonoBehaviour
{
   public GameObject cup;

   // Start is called before the first frame update
   void Start()
   {
 
   }
 
   // Update is called once per frame
   void Update()
   {
        Vector3 cupPos = cup.transform.position;
	if(cupPos.y < -100) {
           SceneManager.LoadScene("Scenes/Game", LoadSceneMode.Single); 
       }
   }
}