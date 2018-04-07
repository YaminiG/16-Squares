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
    private static RectTransform rectTransform;
    private static float xPos;
    private static float yPos;


    void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        Rect rect = rectTransform.rect;
        float newWidth = Screen.width / 6;
        float newHeight = Screen.height / 8;
        rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        xPos = newWidth / 2 + 20.0f;
        yPos = newHeight / 2 + 20.0f;
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
        rectTransform.anchoredPosition = new Vector3(xPos, yPos, 0.0f);
    }

    public static void DisableButton()
    {
        isActive = false;
        rectTransform.anchoredPosition = new Vector3(-9999.0f, yPos, 0.0f);
    }
}
