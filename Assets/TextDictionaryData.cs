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
                    1850f, "This was the original location of the Alexander Black House."
                },
                {
                    1935f, "Alexander Black passes away. The House was then used as a funeral home until 2002."
                },
                {
                    2002f, "It is now a 400-stall parking garage. The Alexander Black House was entirely moved and restored across the street."
                }
            }
        },
        {
            "E3", new Dictionary<float, string>
            {
                {
                    1800f, "Spout Spring provided the first source of water to some town buildings."
                },
                {
                    1890f, "The spring was closed due to typhoid fever, but was reopened in 1891 when the livery stable was removed."
                },
                {
                    1940f, "The spring dried up. It is now covered by the Tech Bookstore."
                }
            }
        }
    };
}
