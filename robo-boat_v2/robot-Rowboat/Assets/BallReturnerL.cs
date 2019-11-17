using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BallReturnerL : MonoBehaviour {

    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.RightHand;
    public Transform ReturnPoint;

    private Valve.VR.InteractionSystem.Hand hand;


    private void Start()
    {
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(TriggerPressed, SteamVR_Input_Sources.Any);
    }

    private void TriggerPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        this.gameObject.transform.position = ReturnPoint.transform.position;
        
    }



}
