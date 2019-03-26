using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoloController : MonoBehaviour {
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(waiter());
    }

    void moveCube() {
        // Randomize force and apply to a direction on the cube
        int num = Random.Range(Constants.MIN_RANGE, Constants.MAX_RANGE);
        Vector3 force = getRandomizedVector(num, Constants.SPEED_POLO);
        rb.AddForce(force);
    }

    Vector3 getRandomizedVector(int num, int multiplier) {
        if (num == 1) {
            return Vector3.forward*multiplier;
        } else if (num == 2) {
            return Vector3.back*multiplier;
        } else if (num == 3) {
            return Vector3.right*multiplier;
        } else {
            return Vector3.left*multiplier;
        }
            
    }

    IEnumerator waiter() {
        while (true) {
            moveCube();
            //Wait for 5 seconds
            yield return new WaitForSecondsRealtime(5);
        }
    }
}