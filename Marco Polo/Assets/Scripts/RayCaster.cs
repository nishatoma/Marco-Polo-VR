using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    // Update is called once per frame
      void Update()
    {
        {

            Ray ray = new Ray();
            RaycastHit hit;
            ray.direction = gameObject.transform.forward;
            ray.origin = gameObject.transform.position;



            if (Physics.Raycast(ray, out hit))
            {
                  Debug.DrawLine(transform.position, hit.point, Color.red);
                
                  if(hit.collider.gameObject.name == "Restart" && OVRInput.GetDown(OVRInput.Button.One))
                  {
                      ProjectUtilities.restart();
                  }
                  else if (hit.collider.gameObject.name == "Exit" && OVRInput.GetDown(OVRInput.Button.One))
                  {
                      ProjectUtilities.exitGame();
                  }
                
            }
        }
    }
}
