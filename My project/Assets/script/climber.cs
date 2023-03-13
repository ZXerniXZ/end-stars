using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class climber : MonoBehaviour
{
    private CharacterController charater;
    public static XRController climbinghand;
    public static Vector3 velpub; 
    // Start is called before the first frame update
    void Start()
    {
        charater = GetComponent<CharacterController>();

       
    }

    void Update()
    {
        charater.Move(transform.rotation * -velpub * Time.fixedDeltaTime);

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (climbinghand)
        {
            Climb();
            Debug.Log("Dentro Climb");
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbinghand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        charater.Move(transform.rotation * -velocity / 2 * Time.fixedDeltaTime);
        velpub = velocity;
        Debug.Log("vel rilevata: "+velocity);
        Debug.Log("time rilevato: " + Time.fixedDeltaTime);


    }
}
