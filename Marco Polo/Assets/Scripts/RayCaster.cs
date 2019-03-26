using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
                  if (hit.collider.gameObject.name == "Restart"){
                        Debug.Log("Restart Mate");
                  }
                else if (hit.collider.gameObject.name == "Play Again"){
                        Debug.Log("Play again lad");
                        
                  }
            }
        }
    }
}
