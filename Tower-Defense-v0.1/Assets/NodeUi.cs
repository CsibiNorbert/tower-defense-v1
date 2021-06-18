using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUi : MonoBehaviour
{
    private Node targetNodeSelected;
    public GameObject CanvasUi;

    public Text upgrateCostText;

    // reference to the button upgrade to make it non-interactale
    public Button upgradeBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTargetNode(Node node)
    {
        targetNodeSelected = node;

        transform.position = targetNodeSelected.GetBuildPosition();

        // upgrade once
        if (!targetNodeSelected.isUpgraded)
        {
            upgrateCostText.text = "$" + targetNodeSelected.turretBlueprint.upgradeCost.ToString();
            upgradeBtn.interactable = true;
        } else
        {
            upgrateCostText.text = "FULL";
            upgradeBtn.interactable = false;
        }

        CanvasUi.SetActive(true);
    }

    public void HideNodeUi()
    {
        CanvasUi.SetActive(false);
    }

    public void Upgrade()
    {
        targetNodeSelected.UpgradeTurret();
        BuildManager.instanceBuildManager.DeselectNode();
    }
}
