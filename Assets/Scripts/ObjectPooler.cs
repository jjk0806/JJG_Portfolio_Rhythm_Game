using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPooler : MonoBehaviour
{
    public GameObject noteObject;
    public List<List<GameObject>> objectPool;
    int createNotesConut = 10;
    public bool more = true;
    void Start()
    {
        objectPool = new List<List<GameObject>>();
           
        for (int i = 0; i < createNotesConut; i++)
        {
            for (int n = 0; n < GameManager.instance.notePosition.Length; n++)
            {
                objectPool.Add(new List<GameObject>());
                GameObject obj = Instantiate(noteObject);
                obj.transform.position = GameManager.instance.notePosition[n].position;

                switch (n)
                {
                    case 0:
                        Note noteLine = obj.GetComponent<Note>();
                        noteLine.line = Note.NoteLine.Line_1;
                        obj.transform.position = GameManager.instance.notePosition[n].position;
                        break;
                    case 1:
                        noteLine = obj.GetComponent<Note>();
                        noteLine.line = Note.NoteLine.Line_2;
                        obj.transform.position = GameManager.instance.notePosition[n].position;
                        break;
                    case 2:
                        noteLine = obj.GetComponent<Note>();
                        noteLine.line = Note.NoteLine.Line_3;
                        obj.transform.position = GameManager.instance.notePosition[n].position;
                        break;
                    case 3:
                        noteLine = obj.GetComponent<Note>();
                        noteLine.line = Note.NoteLine.Line_4;
                        obj.transform.position = GameManager.instance.notePosition[n].position;
                        break;
                }            
                obj.SetActive(false);
                objectPool[n].Add(obj);               
            }
        }                  
    }

    public GameObject GetObject(int lineType)
    {
        foreach (GameObject obj in objectPool[lineType - 1])
        {
            if(!obj.activeInHierarchy)
            {                
                return obj;
            }
        }
        if (more)
        {
            GameObject obj = Instantiate(noteObject);

            switch (lineType)
            {
                case 0:
                    Note noteLine = obj.GetComponent<Note>();
                    noteLine.line = Note.NoteLine.Line_1;
                    obj.transform.position = GameManager.instance.notePosition[lineType].position;
                    break;
                case 1:
                    noteLine = obj.GetComponent<Note>();
                    noteLine.line = Note.NoteLine.Line_2;
                    obj.transform.position = GameManager.instance.notePosition[lineType].position;
                    break;
                case 2:
                    noteLine = obj.GetComponent<Note>();
                    noteLine.line = Note.NoteLine.Line_3;
                    obj.transform.position = GameManager.instance.notePosition[lineType].position;
                    break;
                case 3:
                    noteLine = obj.GetComponent<Note>();
                    noteLine.line = Note.NoteLine.Line_4;
                    obj.transform.position = GameManager.instance.notePosition[lineType].position;
                    break;
            }
            objectPool[lineType - 1].Add(obj);
            return obj;
        }

        return null;
    }
}
