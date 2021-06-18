using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUi : MonoBehaviour
{
    private Node targetNodeSelected;
    public GameObject CanvasUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTargetNode(Node node)
    {
        targetNodeSelected = node;

        transform.position = targetNodeSelected.GetBuildPosition();
        CanvasUi.SetActive(true);
    }

    public void HideNodeUi()
    {
        CanvasUi.SetActive(false);
    }
}
