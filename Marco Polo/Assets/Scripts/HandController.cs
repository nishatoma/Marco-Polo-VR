using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandController : MonoBehaviour
{
    public GameObject wave;
    GameObject marcoSound;
    private Canvas canvas;
    bool poloFound = false;

    void Start() {
        canvas = GameObject.FindGameObjectWithTag(Constants.TAG_CANVAS).GetComponent<Canvas>();
        canvas.enabled = false;
       
    }

    void LateUpdate() {
        triggerCanvas();
    }

    

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag.Equals(Constants.TAG_POLO)) {
            poloFound = true;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            pausePoloSounds();
            stopMovingPolo(collision);
        } else if (collision.gameObject.tag.Equals(Constants.TAG_OBSTACLE)) {
            createWaveAtCollisionPoint(collision);
            playMarco();
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

    void exitGame() {
        // save any game data here
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void restart() {
        SceneManager.LoadScene(Constants.SCENE_NAME);
    }

    void triggerCanvas() {
        if (poloFound) {
            canvas.enabled = true;
        } 
    }
}