using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private GameObject cam;

    [SerializeField] private float parallaxEffect;

    private float length;

    private float xPosition;

    void Start()
    {
        cam = GameObject.Find("Main Camera");

        length = GetComponent<SpriteRenderer>().bounds.size.x;

        xPosition = transform.position.x;
    }

    
    void Update()
    {
        float distancMoved = cam.transform.position.x * (1 - parallaxEffect);

        float distanceToMove = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

        if (distancMoved > xPosition + length)
        {
            xPosition += length;
        } else if (distancMoved < xPosition - length)
        {
            xPosition -= length;
        }
    }
}
