using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public enum NoteLine { Line_1, Line_2, Line_3, Line_4 }
    public float judgeTime;
    public float dropSpeed;

    GameManager.Judge noteJudge;
    public NoteLine line;
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        key = SetLineProcess();
        Debug.Log("key값 변경 " + key);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.status == GameManager.GameStatus.PLAY)
        JudgeProcess();
    }

    void OnEnable()
    {
        noteJudge = GameManager.Judge.None;
    }

    void Move()
    {
        transform.Translate(Vector2.down * dropSpeed);
    }

    KeyCode SetLineProcess()
    {
        switch (line)
        {
            case NoteLine.Line_1:
                return GameManager.instance.controller.keys[0];               
            case NoteLine.Line_2:
                return GameManager.instance.controller.keys[1];              
            case NoteLine.Line_3:
                return GameManager.instance.controller.keys[2];              
            case NoteLine.Line_4:
                return GameManager.instance.controller.keys[3];
            default:
                return KeyCode.None;
        }
    }
    
    void JudgeProcess()
    {
        if (Input.GetKeyDown(key))
        {
            bool canHit = IsWithinRange(AudioManager.instance.audioSource.time, judgeTime, 400f);
            if (canHit)
            {               
                gameObject.SetActive(false);
                Debug.Log("성공");
            }
            else
            {
                Debug.Log("실패");
            }
        }
    }

    bool IsWithinRange(float musicTime, float judgeTime, float rangeMilliseconds)
    {
        float rangeSeconds = rangeMilliseconds / 1000f;
        
        return (musicTime >= judgeTime - rangeSeconds && musicTime <= judgeTime + rangeSeconds);
    }
}
