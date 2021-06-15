using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instanceBuildManager;

    private TurretBlueprint turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject missleTurretPrefab;
    public bool CanBuild {
        get { return turretToBuild != null; } 
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
        // Selecting at the start of the game, but commented out because we added the purchase turrets method
        //turretToBuild = standardTurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
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

        Debug.Log("Turret built! Money left:" + PlayerStats.money);
    }
}
