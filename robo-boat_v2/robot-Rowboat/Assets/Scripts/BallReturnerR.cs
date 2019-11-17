using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BallReturnerR : MonoBehaviour {

    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.RightHand;
    public Transform ReturnPoint;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabtgg;

    private Valve.VR.InteractionSystem.Hand hand;


    private void Start()
    {
        grabtgg.AddOnStateDownListener(TriggerDown, handType);
        grabtgg.AddOnStateDownListener(TriggerUp, handType);
        //SteamVR_Input_ActionSet_Rowboat
        //.AddOnStateDownListener(TriggerDown, handType);
        //TriggerDown.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up");
        this.gameObject.transform.position = ReturnPoint.transform.position;
        //this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");        
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    public void ResetPosition()
    {
        this.gameObject.transform.position = ReturnPoint.transform.position;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }


}
