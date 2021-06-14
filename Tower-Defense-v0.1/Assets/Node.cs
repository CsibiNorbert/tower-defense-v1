using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset; // this is to bring the object above the node
    private GameObject currentTurretOnNode;
    private Renderer rend;
    private Color startNodeColor;

    // This class keeps track of whether or not we have build something on this node.
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startNodeColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startNodeColor;
    }

    private void OnMouseDown()
    {
        if (currentTurretOnNode != null)
        {
            Debug.Log("Something in, you cannot build it");
            return;
        }

        // build a turret
        GameObject turretToBuild = BuildManager.instanceBuildManager.GetTurretToBuild();

        currentTurretOnNode = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
}
