using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject wave;
    GameObject marcoSound;
    
    // Sound source name
    private const string MARCO = "sound_marco"; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag.Equals("polo")) {
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        } else {
            createWaveAtCollisionPoint(collision);
            playMarco();
        }

        
    }

    void createWaveAtCollisionPoint(Collision collision) {
        // What position do we generate the ripple in?
        Vector3 wavePosition = collision.contacts[0].point;
        Debug.Log("Wave position wrtf: " + wavePosition);
        // Generate at the point of contact with the object.
        GameObject waveClone2 = Instantiate(wave, wavePosition, gameObject.transform.rotation);
    }

    void playMarco() {
        marcoSound = GameObject.Find(MARCO);
        marcoSound.GetComponent<AudioSource>().Play();
    }
}
