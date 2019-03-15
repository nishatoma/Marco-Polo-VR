using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoloController : MonoBehaviour
{
    Rigidbody rigidbody;
    int MAX_RANGE = 5;
    int MIN_RANGE = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moveCube() {
        // Randomize force and apply to a direction on the cube
        int num = Random.Range(MIN_RANGE, MAX_RANGE);
        Vector3 force = getRandomizedVector(num, 2000);
        rigidbody.AddForce(force);
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
            //Wait for 4 seconds
            yield return new WaitForSecondsRealtime(3);
            // moveCube();
        }
    }
}
