using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public GameObject middleground;
    public float scrollSpeed = 1.0f;
    public float regenXPosition = 10.0f;

    private List<GameObject> backgroundObjects = new List<GameObject>();

    void Start()
    {
        CreateInitialBackground();
    }

    void CreateInitialBackground()
    {
        float cameraHeight = Camera.main.orthographicSize * 2.0f;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        for (float x = 0; x < cameraWidth + regenXPosition; x += regenXPosition)
        {
            GameObject bg = Instantiate(middleground, new Vector3(x, 0, 0), Quaternion.identity);
            backgroundObjects.Add(bg);
        }
    }

    void Update()
    {
        ScrollBackground();
        RegenerateBackground();
    }

    void ScrollBackground()
    {
        foreach (var bg in backgroundObjects)
        {
            bg.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
    }

    void RegenerateBackground()
    {
        float cameraWidth = Camera.main.orthographicSize * 2.0f * Camera.main.aspect;

        foreach (var bg in backgroundObjects)
        {
            if (bg.transform.position.x < -cameraWidth / 2.0f)
            {
                float newX = backgroundObjects[backgroundObjects.Count - 1].transform.position.x + regenXPosition;
                bg.transform.position = new Vector3(newX, 0, 0);
            }
        }
    }
}
