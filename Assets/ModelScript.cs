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

    GameObject[] gobjs;

    public Text buttonText;

    LeanScale leanScaleScript;

    GameObject slider;

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
        slider = GameObject.Find("Slider");
    }


    private void SelectModel()
    {
        ResetAll();
        gameObject.SetActive(true);
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;
        transform.position = new Vector3(0.0f, y, 0.0f);
        ResetButtonScript.SetModelPosition(UnselectModel);
        SliderScript.SetTextData(gameObject.name);
        leanScaleScript.enabled = true;
    }

    private void UnselectModel()
    {
        ResetAll();
        transform.position = new Vector3(x, y, z);
        transform.rotation = new Quaternion();
        transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        ResetButtonScript.DisableButton();
        SliderScript.DisableSlider();
        leanScaleScript.enabled = false;
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