using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animhand : MonoBehaviour
{
    public InputActionProperty pinchanim;
    public InputActionProperty gripanim;

    public Animator handanimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggervalue = pinchanim.action.ReadValue<float>();
        handanimator.SetFloat("Trigger", triggervalue);
      

        float gripvalue = gripanim.action.ReadValue<float>();
        handanimator.SetFloat("Grip", gripvalue);
    }
}
