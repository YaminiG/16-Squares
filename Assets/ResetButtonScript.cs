using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButtonScript : MonoBehaviour {

    GameObject buttonObject;

    public static bool isActive = false;
    private static Vector3 oldPosition;
    private static GameObject currentModelObject;
    private static Action callbackbackback;
    private static Button resetButton;
    private static float xPos;
    private static float yPos;


    void Start ()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Rect rect = rectTransform.rect;
        rectTransform.sizeDelta = new Vector2(Screen.width / 6, Screen.height / 8);
        xPos = rect.width / 2 + 40.0f;
        yPos = rect.height / 2 + 30.0f;
        buttonObject = GameObject.Find("ResetButton");
        resetButton = buttonObject.GetComponent<Button>();
        resetButton.onClick.AddListener(OnResetButtonClicked);

    }

    private void OnResetButtonClicked()
    {
        if (isActive)
        {
            Debug.Log("Reset Clicked");
            callbackbackback();
            isActive = false;
        }
        else
        {
            Debug.Log("Reset Clicked, sure, but it was not active so I don't know why this would ever be displayed.");
        }
    }

    public static void SetModelPosition(Action callback)
    {
        callbackbackback = callback;
        EnableButton();
    }

    public static void EnableButton()
    {
        isActive = true;
        resetButton.transform.position = new Vector3(xPos, yPos, 0.0f);
    }

    public static void DisableButton()
    {
        isActive = false;
        resetButton.transform.position = new Vector3(-999f, -999f, 0.0f);
    }
}
