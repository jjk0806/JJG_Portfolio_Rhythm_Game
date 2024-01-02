using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<Button> buttons;
    public List<KeyCode> keys = new List<KeyCode>();
    void Awake()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            keys[i] = buttons[i].GetComponent<Button>().key;
        }
    }

    void Update()
    {

    }
}
