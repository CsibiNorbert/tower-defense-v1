using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instanceBuildManager;

    private GameObject turretToBuild;

    public GameObject standardTurretPrefab;

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
        turretToBuild = standardTurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
