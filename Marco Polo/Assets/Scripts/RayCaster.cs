using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                
                  if(hit.collider.gameObject.name == "Restart" && OVRInput.GetDown(OVRInput.Button.One))
                  {
                      restart();
                  }
                  else if (hit.collider.gameObject.name == "Exit" && OVRInput.GetDown(OVRInput.Button.One))
                  {
                      exitGame();
                  }
                
            }
        }
    }

    void exitGame() 
    {
        // save any game data here
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void restart() 
    {
        SceneManager.LoadScene(Constants.SCENE_NAME);
    }
}
