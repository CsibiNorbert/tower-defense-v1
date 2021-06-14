using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuildManager buildManager;

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
    public void PurchaseStandardTurret()
    {
        // We set what we want to build from the shop, but we store the turrets inside the build manager
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissleTurret()
    {
        buildManager.SetTurretToBuild(buildManager.missleTurretPrefab);
    }
}
