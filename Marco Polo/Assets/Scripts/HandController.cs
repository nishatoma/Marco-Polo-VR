using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{

    public enum VibrationForce
    {
     Light,
     Medium,
     Hard,
    }

    [SerializeField]
    OVRInput.Controller controllerMask;

    public GameObject wave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        // What position do we generate the ripple in?
        Vector3 wavePosition = collision.contacts[0].point;
        Debug.Log("Wave position wrtf: " + wavePosition);
        // Generate at the point of contact with the object.
        GameObject waveClone2 = Instantiate(wave, wavePosition, gameObject.transform.rotation);
    }

     void Vibrate(VibrationForce vibrationForce)
     {
         var channel = OVRHaptics.RightChannel;
         if (controllerMask == OVRInput.Controller.LTouch)
             channel = OVRHaptics.LeftChannel;
 
         switch (vibrationForce)
         {
             case VibrationForce.Light:
                 channel.Preempt(clipLight);
                 break;
             case VibrationForce.Medium:
                 channel.Preempt(clipMedium);
                 break;
             case VibrationForce.Hard:
                 channel.Preempt(clipHard);
                 break;
         }
     }
}
