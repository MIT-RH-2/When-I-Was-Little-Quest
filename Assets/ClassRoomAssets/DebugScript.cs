using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestFunction(); 
    }


    void TestFunction() {
    	Debug.Log("Script Fired Test"); 
    }

     public void Hit() {
        Debug.Log("ITEM WAS HIT! "); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
