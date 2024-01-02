using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public KeyCode key;

    [SerializeField]
    GameObject baseKey;
    [SerializeField]
    GameObject pressKey;
    [SerializeField]
    GameObject keyLine;

    [SerializeField]
    bool isPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            isPress = true;
        }
        else
        {
            isPress = false;
        }

        if (isPress)
        {
            baseKey.SetActive(false);
            pressKey.SetActive(true);
            keyLine.SetActive(true);
        }
        else
        {
            baseKey.SetActive(true);
            pressKey.SetActive(false);
            keyLine.SetActive(false);
        }
    }
}
