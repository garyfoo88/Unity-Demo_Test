using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    //private Vector3 startPos --> position object
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //startPos = transform.position --> position of object initialisation
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        //repeatWidth = GetComponent<BoxCollider>().size.x /2 --> get half of boxcollier's size
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x < startPos.x - repeatWidth) --> if x-position of object is less than the starting x position minus half of box collider size)
        if (transform.position.x < startPos.x - repeatWidth)
        {
            //transform.position = startPos (reset starting position);
            transform.position = startPos;
        }
    }
}
