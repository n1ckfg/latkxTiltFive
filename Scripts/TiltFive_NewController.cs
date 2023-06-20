﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Input = TiltFive.Input;

public class TiltFive_NewController : MonoBehaviour {

    public TiltFiveDemos.T5UIInput device;

    public bool triggerPressed = false;
    public bool padPressed = false;
    public bool gripped = false;
    public bool menuPressed = false;
    public bool triggerDown = false;
    public bool padDown = false;
    public bool gripDown = false;
    public bool menuDown = false;
    public bool triggerUp = false;
    public bool padUp = false;
    public bool gripUp = false;
    public bool menuUp = false;

    public bool padDirUp = false;
    public bool padDirDown = false;
    public bool padDirLeft = false;
    public bool padDirRight = false;
    public bool padDirCenter = false;

    public Vector2 touchpad = new Vector2(0f, 0f);

    [HideInInspector] public Vector3 startPos = Vector3.zero;
    [HideInInspector] public Vector3 endPos = Vector3.zero;
    [HideInInspector] public float triggerVal;


    private float touchPadLimit = 0.6f; // 0.7f;

    private void Update() {
        resetButtons();
        checkTriggerVal();
        checkPadDir();

        if (device) {
            triggerPressed = true;
            triggerDown = true;
            startPos = transform.position;
        } else if (device) {
            triggerPressed = false;
            triggerUp = true;
            endPos = transform.position;
        }

        if (device) {
            padPressed = true;
            padDown = true;
        } else if (device) {
            padPressed = false;
            padUp = true;
        }

        if (device) {
            gripped = true;
            gripDown = true;
        } else if (device) {
            gripped = false;
            gripUp = true;
        }

        if (device) {
            menuPressed = true;
            menuDown = true;
        } else if (device) {
            menuPressed = false;
            menuUp = true;
        }
    }

    private void resetButtons() {
        triggerDown = false;
        padDown = false;
        gripDown = false;
        menuDown = false;
        triggerUp = false;
        padUp = false;
        gripUp = false;
        menuUp = false;

        padDirUp = false;
        padDirDown = false;
        padDirLeft = false;
        padDirRight = false;
        padDirCenter = true;
    }

    private void checkTriggerVal() {
        //triggerVal = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
    }

    private void checkPadDir() {
        //touchpad = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

        if (touchpad.y > touchPadLimit) {
            padDirUp = true;
            padDirDown = false;
            padDirCenter = false;
        } else if (touchpad.y < -touchPadLimit) {
            padDirUp = false;
            padDirDown = true;
            padDirCenter = false;
        }

        if (touchpad.x > touchPadLimit) {
            padDirLeft = true;
            padDirRight = false;
            padDirCenter = false;
        } else if (touchpad.x < -touchPadLimit) {
            padDirLeft = false;
            padDirRight = true;
            padDirCenter = false;
        }
    }

    float defaultVibrationVal = 2f;
    public void vibrateController() {
        //int ms = (int)defaultVibrationVal * 1000;
        //device.TriggerHapticPulse((ushort)ms, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
    }

    public void vibrateController(float val) {
        //int ms = (int)val * 1000;
        //device.TriggerHapticPulse((ushort)ms, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
    }

}