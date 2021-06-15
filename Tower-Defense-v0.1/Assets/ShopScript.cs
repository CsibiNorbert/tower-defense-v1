using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuildManager buildManager;
    //TODO: find a way to dynamically create the turets.

    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instanceBuildManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called from UI element, to communicate with the build manager and currency amount
    public void SelectStandardTurret()
    {
        // We set what we want to build from the shop, but we store the turrets inside the build manager
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissleTurret()
    {
        buildManager.SelectTurretToBuild(missleLauncher);
    }
}
