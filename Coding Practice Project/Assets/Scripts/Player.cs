using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Classes[] items = new Classes[2];
    // Start is called before the first frame update
    void Start()
    {
        items[0] = new Classes(0, "LOL");
        items[1] = new Classes(7, "mama");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
