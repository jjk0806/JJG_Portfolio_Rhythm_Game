using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }
    public enum Judge { None, KOOL, COOL, GOOD, MISS, FAIL }
    public enum GameStatus { START, PLAY, STOP, EDIT }
    public Transform[] notePosition;
    public float noteSpeed;
    public Controller controller;
    public GameStatus status;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        status = GameStatus.STOP;
        if(controller != null)
        controller = controller.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SetGameStatus()
    {
        switch (status)
        {

        }
    }
}
