using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDictionaryData : MonoBehaviour {
    public static Dictionary<string, Dictionary<float, string>> Data = new Dictionary<string, Dictionary<float, string>>
    {
        {
            "I1", new Dictionary<float, string>
            {
                {
                    1850f, "University Book Store has been a leading provider of overly expensive books and merchandise since 1860."
                },
                {
                    1950f, "After 1950, everything got even more expensive."
                }
            }
        }
    };
}
