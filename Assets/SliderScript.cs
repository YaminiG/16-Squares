using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {


    static Text text;
  
    static string modelName;
    static Dictionary<float, string> dict;
    static List<float> keys;


    static GameObject sliderObject;
    static Slider slider;
    static RectTransform sliderTransform;

    // Use this for initialization
    void Start () {
        text = GameObject.Find("DetailText").GetComponent<Text>();
        sliderObject = GameObject.Find("Slider");
        sliderTransform = sliderObject.GetComponent<RectTransform>();

    }

    public void ChangeText(float value)
    {
        for (int i = keys.Count - 1; i >= 0; i--)
        {
            float year = keys[i];
            if (value > year)
            {
                text.text = dict[year];
                break;
            }
        }
    }

    public static void SetTextData(string _modelName)
    {
        modelName = _modelName;
        if (TextDictionaryData.Data.ContainsKey(modelName))
        {
            dict = TextDictionaryData.Data[modelName];
            keys = new List<float>(dict.Keys);
            EnableSlider(keys[0]);
        }
        else
        {
            DisableSlider();
        }
    }

    public static void EnableSlider(float minValue)
    {
        slider = sliderObject.GetComponent<Slider>();
        sliderTransform.anchoredPosition = new Vector3(0.0f, 100.0f, 0.0f);
        slider.minValue = minValue;
        slider.value = minValue;
        text.text = dict[minValue];
    }

    public static void DisableSlider()
    {
        keys = new List<float>();
        text.text = "";
        sliderTransform.localPosition = new Vector3(-9999.0f, 100.0f, 0.0f);
    }


}
