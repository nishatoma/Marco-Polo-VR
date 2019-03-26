using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject wave;
    GameObject marcoSound;

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag.Equals(Constants.TAG_POLO)) {
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        } else if (collision.gameObject.tag.Equals(Constants.TAG_OBSTACLE)) {
            createWaveAtCollisionPoint(collision);
            playMarco();
        }
    }

    void createWaveAtCollisionPoint(Collision collision) {
        // What position do we generate the ripple in?
        Vector3 wavePosition = collision.contacts[0].point;
        // Generate at the point of contact with the object.
        GameObject waveClone2 = Instantiate(wave, wavePosition, gameObject.transform.rotation);
    }

    void playMarco() {
        marcoSound = GameObject.Find(Constants.SOUND_MARCO);
        marcoSound.GetComponent<AudioSource>().Play();
    }
}