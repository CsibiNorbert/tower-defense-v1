using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset; // this is to bring the object above the node

    [Header("Optional")]
    public GameObject currentTurretOnNode;

    private Renderer rend;
    private Color startNodeColor;

    BuildManager buildManager;

    // This class keeps track of whether or not we have build something on this node.
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startNodeColor = rend.material.color;
        startNodeColor = rend.material.color;

        buildManager = BuildManager.instanceBuildManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseEnter()
    {
        // check if hovering a UI element that it`s on the way, in our case Node
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startNodeColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (currentTurretOnNode != null)
        {
            Debug.Log("Something in, you cannot build it");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
}
