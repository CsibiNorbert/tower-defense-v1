using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instanceBuildManager;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public GameObject buildEffect;
    public NodeUi nodeUi;

    public bool CanBuild {
        get { return turretToBuild != null; } 
    }

    public bool HasMoney
    {
        get { return PlayerStats.money >= turretToBuild.costOfTurret; }
    }

    public void Awake()
    {
        if (instanceBuildManager != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        instanceBuildManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        // This is because we want either selected turret or node
        // When we enable one, we disable the other
        turretToBuild = null;

        nodeUi.SetTargetNode(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUi.HideNodeUi();
    }

    public void BuildTurretOn(Node node) {

        if (PlayerStats.money < turretToBuild.costOfTurret)
        {
            Debug.Log("Not enough money to build this turret");
            return;
        }

        PlayerStats.money -= turretToBuild.costOfTurret;

        // turret to build
        GameObject turret = (GameObject)Instantiate(turretToBuild.turretPrefab, node.GetBuildPosition(), Quaternion.identity); // Quaterion identity means we won`t rotate it at all, if we want rotation we simply put transform.rotation
        node.currentTurretOnNode = turret;

        // We store it into a variable so that we can get rid of it
        GameObject buildEff = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(buildEff, 4f);

        Debug.Log("Turret built! Money left:" + PlayerStats.money);
    }
}
