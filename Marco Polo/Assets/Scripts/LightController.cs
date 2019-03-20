using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] allLights = GameObject.FindGameObjectsWithTag ("dev_light"); 
         
        if (Input.GetKeyDown(KeyCode.M)) {
            foreach (GameObject i in allLights) { 
                i.SetActive(!i.active); 
            }
        }
    }
}
