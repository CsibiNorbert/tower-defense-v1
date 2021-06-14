using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset; // this is to bring the object above the node
    private GameObject currentTurretOnNode;
    private Renderer rend;
    private Color startNodeColor;

    BuildManager buildManager;

    // This class keeps track of whether or not we have build something on this node.
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startNodeColor = rend.material.color;

        buildManager = BuildManager.instanceBuildManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        // check if hovering a UI element that it`s on the way, in our case Node
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (CanBuildTurret(buildManager.GetTurretToBuild()))
        {
            rend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startNodeColor;
    }

    private void OnMouseDown()
    {
        // turret to build
        GameObject turretToBuild = buildManager.GetTurretToBuild();

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!CanBuildTurret(turretToBuild))
        {
            return;
        }

        if (currentTurretOnNode != null)
        {
            Debug.Log("Something in, you cannot build it");
            return;
        }

        currentTurretOnNode = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private bool CanBuildTurret(GameObject turretToBuild)
    {
        if (turretToBuild == null)
        {
            return false;
        }

        return true;
    }
}
