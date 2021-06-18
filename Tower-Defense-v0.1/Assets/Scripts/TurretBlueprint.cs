using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // unity will save and load the values for us.
public class TurretBlueprint
{
    public GameObject turretPrefab;
    public int costOfTurret;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
