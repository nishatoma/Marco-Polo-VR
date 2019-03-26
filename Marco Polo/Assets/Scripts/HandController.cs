using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandController : MonoBehaviour
{
    public GameObject wave;
    GameObject marcoSound;
    private Canvas canvas;
    private LineRenderer line;
    bool poloFound = false;

    void Start() {
        canvas = GameObject.FindGameObjectWithTag(Constants.TAG_CANVAS).GetComponent<Canvas>();
        line = GameObject.Find("Line").GetComponent<LineRenderer>();

        line.enabled = false;
        canvas.enabled = false;
       
    }

    void LateUpdate() {
        triggerCanvas();
    }

    

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag.Equals(Constants.TAG_POLO)) {
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            pausePoloSounds();
            stopMovingPolo(collision);
            playVictorySound();
            Invoke("poloWasFound", 6);
        } else if (collision.gameObject.tag.Equals(Constants.TAG_OBSTACLE)) {
            createWaveAtCollisionPoint(collision);
            playMarco();
            Invoke("playPoloSound", 1);
        }
    }

    void createWaveAtCollisionPoint(Collision collision) {
        // What position do we generate the ripple in?
        Vector3 wavePosition = collision.contacts[0].point;
        // Generate at the point of contact with the object.
        GameObject waveClone = Instantiate(wave, wavePosition, gameObject.transform.rotation);
        // Destroy the ripple after certain amount of time.
        Destroy(waveClone, Constants.WAVE_LIFE_TIME);
    }

    void playMarco() {
        marcoSound = GameObject.Find(Constants.SOUND_MARCO);
        marcoSound.GetComponent<AudioSource>().Play();
    }

    void pausePoloSounds() {
        GameObject polo = GameObject.FindGameObjectWithTag(Constants.TAG_POLO);
        polo.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        polo.transform.GetChild(1).GetComponent<AudioSource>().Stop();
    }

    void stopMovingPolo(Collision collision) {
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void triggerCanvas() {
        if (poloFound) {
            canvas.enabled = true;
            line.enabled = true;
        } 
    }

    void playPoloSound() {
        GameObject polo = GameObject.FindGameObjectWithTag(Constants.TAG_POLO);
        polo.transform.GetChild(1).GetComponent<AudioSource>().Play();
    }

    void playVictorySound() {
        GameObject.Find(Constants.SOUND_VICTORY).GetComponent<AudioSource>().Play();
    }

    void poloWasFound() {
        poloFound = true;
    }
}