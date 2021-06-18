using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instanceBuildManager;

    //private TurretBlueprint turretToBuild;
    public TurretBlueprint TurretToBuild { get; private set; }
    private Node selectedNode;

    public GameObject buildEffect;
    public NodeUi nodeUi;

    public bool CanBuild {
        get { return TurretToBuild != null; } 
    }

    public bool HasMoney
    {
        get { return PlayerStats.money >= TurretToBuild.costOfTurret; }
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
        TurretToBuild = turretBlueprint;
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
        TurretToBuild = null;

        nodeUi.SetTargetNode(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUi.HideNodeUi();
    }

}
