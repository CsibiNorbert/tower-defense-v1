using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracript : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderWidth = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("s") || Input.mousePosition.x <= Screen.width - panBorderWidth)
        //{
        //    transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        //}
    }
}
