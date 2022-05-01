using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    public GameObject objectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectPrefab.GetComponent<Renderer>().sharedMaterial.color = changeColor(Color.red);
        }
    }

    void TellMeThePosition(GameObject lol)
    {
        Debug.Log("Position" + lol.transform.position);
    }

    Color changeColor(Color newColor)
    {
        return newColor;
    }
}
