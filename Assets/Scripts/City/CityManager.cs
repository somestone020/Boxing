﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPos;
    public INPUTTYPE inputType;
    public delegate void DelegateTouchEvent(Vector3 direction);
    public static event DelegateTouchEvent onTouchScreenEvent;
    private Vector3 cameraVec = new Vector3(104f,3f,102f);

    private void Awake()
    {
        player = Instantiate(Resources.Load("PlayerTest"), playerPos.transform.position, Quaternion.identity) as GameObject;
#if UNITY_IOS || UNITY_ANDROID && !UNITY_EDITOR
			inputType = INPUTTYPE.TOUCHSCREEN;
#else
        inputType = INPUTTYPE.KEYBOARD;
#endif
    }


    void Start()
    {
        UIManager UI = GameObject.FindObjectOfType<UIManager>();
        float fadeoutTime = 1f;
        if(inputType == INPUTTYPE.TOUCHSCREEN) GameObject.FindObjectOfType<UIManager>().ShowMenu("TouchScreenControls");
        else GameObject.FindObjectOfType<UIManager>().ShowMenu("");
     

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // 返回键
        {
            GameObject.FindObjectOfType<UIManager>().ShowMenu("MainMenu");
        }
    }

    public void OnTouchScreenEvent(Vector3 direction)
    {
        if (onTouchScreenEvent != null) onTouchScreenEvent(direction);
    }



}

