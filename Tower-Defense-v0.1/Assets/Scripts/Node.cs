using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset; // this is to bring the object above the node

    [HideInInspector]
    public GameObject currentTurretOnNode;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

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

    internal void SellCurrentTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        // Spawn a cool effect
        GameObject sellEff = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(sellEff, 2f);

        Destroy(currentTurretOnNode);
        turretBlueprint = null;
    }

    private void OnMouseExit()
    {
        rend.material.color = startNodeColor;
    }

    private void OnMouseDown()
    {
        // We check if we currently clicking a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // If turret is sitting currently on this node
        if (currentTurretOnNode != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.TurretToBuild);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade this turret");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;

        // get rid of the old one
        Destroy(currentTurretOnNode);

        // building a new upgraded one
        GameObject turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity); // Quaterion identity means we won`t rotate it at all, if we want rotation we simply put transform.rotation
        currentTurretOnNode = turret;

        // We store it into a variable so that we can get rid of it
        GameObject buildEff = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEff, 4f);

        isUpgraded = true;
    }

    private void BuildTurret(TurretBlueprint turretB)
    {
        if (PlayerStats.money < turretB.costOfTurret)
        {
            Debug.Log("Not enough money to build this turret");
            return;
        }

        PlayerStats.money -= turretBlueprint.costOfTurret;

        // turret to build
        GameObject turret = (GameObject)Instantiate(turretB.turretPrefab, GetBuildPosition(), Quaternion.identity); // Quaterion identity means we won`t rotate it at all, if we want rotation we simply put transform.rotation
        currentTurretOnNode = turret;
        turretBlueprint = turretB;

        // We store it into a variable so that we can get rid of it
        GameObject buildEff = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEff, 4f);

        Debug.Log("Turret built!");
    }
}
