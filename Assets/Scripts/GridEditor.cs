using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEditor : MonoBehaviour
{
    public GameObject linePrefab;
    public Transform lineParent;
    public GameObject notePrefab;

    public float bpm;
    public float musicLength;
    public float snapGridSize;

    void Start()
    {
        DrawGridLines();
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // Assuming left-click for placing notes
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is a line
                if (hit.collider.CompareTag("Line"))
                {
                    // Snap and place the note at the clicked line
                    SnapAndPlaceNoteAtLine(hit.collider.transform);
                }
            }
        }
    }

    private void DrawGridLines()
    {
        float secondsPerBeat = 60f / bpm;
        int numHorizontalLines = Mathf.CeilToInt(musicLength / secondsPerBeat);

        float yOffset = -4f;
        for (int i = 0; i < numHorizontalLines; i++)
        {
            GameObject horizontalLine = Instantiate(linePrefab, lineParent);
            horizontalLine.transform.localPosition = new Vector3(0f, yOffset, 0f);
            yOffset += secondsPerBeat;
        }
    }

    // Snap function
    public void SnapToLines(Transform objectToSnap)
    {
        float minDistance = Mathf.Infinity;
        Transform closestLine = null;

        // Get all child objects (lines) under the parent
        List<Transform> lines = new List<Transform>();
        foreach (Transform child in linePrefab.transform)
        {
            lines.Add(child);
        }

        // Calculate the distance to each line and find the closest one
        foreach (Transform line in lines)
        {
            float distance = Vector3.Distance(objectToSnap.position, line.position);
            if (distance < minDistance && distance < snapGridSize)
            {
                minDistance = distance;
                closestLine = line;
            }
        }

        // If a close line is found, snap the object to it
        if (closestLine != null)
        {
            objectToSnap.position = closestLine.position;
        }
    }

    private void SnapAndPlaceNoteAtLine(Transform line)
    {
        // Instantiate note at the snapped position
        GameObject note = Instantiate(notePrefab, line.position, Quaternion.identity);
        // Optionally, you can modify the note position for better alignment
        SnapToLines(note.transform);
    }
}
