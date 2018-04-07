using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelScript : MonoBehaviour
{

    float rotSpeed = 200;

    float x = 0.0f, y = 0.0f, z = 0.0f;
    float scaleX, scaleY, scaleZ;

    bool isSelected = false;

    Quaternion existingRotation;
    GameObject[] gobjs;

    public Text buttonText;
    GameObject capsuleObject;
    LeanScale leanScaleScript;

    // Rotation
    private void OnMouseDrag()
    {
        if (isSelected)
        {
            Debug.Log("ON MOUSE DRAG");

            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up, -rotX);
        }

    }

    private void Start()
    {
        gobjs = GameObject.FindGameObjectsWithTag("target");
        Debug.Log(gameObject.name);
        leanScaleScript = gameObject.GetComponent<LeanScale>();
        leanScaleScript.enabled = false;
        string capsuleName = gameObject.name + "Capsule";
        Transform capsuleTransform = transform.Find(capsuleName);
        if (capsuleTransform)
        {
            capsuleObject = capsuleTransform.gameObject;
            capsuleTransform.localPosition = Vector3.zero;
        }
    }


    private void SelectModel()
    {
        ResetAll();
        gameObject.SetActive(true);
        x = transform.localPosition.x;
        y = transform.localPosition.y;
        z = transform.localPosition.z;
        Debug.Log(x + ", " + y + ", " + z);
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;
        existingRotation = transform.rotation;
        if (PositionDictionary.Data.ContainsKey(gameObject.name))
        {
            transform.localPosition = PositionDictionary.Data[gameObject.name];
        }
        else
        {
            transform.localPosition = new Vector3(0.0f, y, 0.0f);
        }
        ResetButtonScript.SetModelPosition(UnselectModel);
        SliderScript.SetTextData(gameObject.name);
        leanScaleScript.enabled = true;
        if (capsuleObject)
        {
            capsuleObject.SetActive(false);
        }
    }

    private void UnselectModel()
    {
        ResetAll();
        transform.localPosition = new Vector3(x, y, z);
        transform.rotation = existingRotation;
        transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        ResetButtonScript.DisableButton();
        SliderScript.DisableSlider();
        leanScaleScript.enabled = false;
        if (capsuleObject)
        {
            capsuleObject.SetActive(true);
        }
    }

    private void ResetAll()
    {
        isSelected = !isSelected;
        for (int i = 0; i < gobjs.Length; i++)
        {
            Debug.Log((i + 1) + ". " + gobjs[i].name);
            gobjs[i].SetActive(!isSelected);
        }
    }

    private void OnMouseUp()
    {
        if (isSelected)
        {
            return;
        }
        Debug.Log("OnMouseUp");
        SelectModel();

    }

}