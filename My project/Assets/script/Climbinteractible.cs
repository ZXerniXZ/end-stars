using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Climbinteractible : XRBaseInteractable
{
    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        Debug.Log("OnSelectEntered");

        climber.climbinghand = interactor.GetComponent<XRController>();
        Debug.Log("climbhand="+ climber.climbinghand.controllerNode);

    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

        Debug.Log("OnSelectEntered exit");
        if (climber.climbinghand && climber.climbinghand.name == interactor.name)
        {
            climber.climbinghand = null;
        }
    }
}
