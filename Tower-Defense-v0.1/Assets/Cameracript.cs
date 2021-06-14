using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracript : MonoBehaviour
{
    private bool moveMap = true;
    public float scrollSpeed = 2.1f;
    public float maxZoom = 45f;
    public float minZoom = 20f;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO, when stopping go to initial camera pos.
        if (Input.GetKeyDown(KeyCode.M))
        {
            moveMap = !moveMap;
        }

        // TODO: Pan the maximum y & x
        MoveCamera();
        ZoomCamera();
    }

    private void ZoomCamera()
    {
        // It gives us a number when scrolling, depending on how quickly we scroll
        float zoomScroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 currentPosition = transform.position;

        // We added the "1000" because we have small scroll wheel values
        currentPosition.y -= zoomScroll * 1000 * scrollSpeed * Time.deltaTime;
        // We restrict zooming further
        currentPosition.y = Mathf.Clamp(currentPosition.y, minZoom, maxZoom);
        transform.position = currentPosition;
    }

    private void MoveCamera()
    {
        if (!moveMap)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
