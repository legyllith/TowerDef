﻿using UnityEngine;
using UnityEngine.UI;

public class NodeUi : MonoBehaviour
{
    private Node target;
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;
    
    public void SetTarget (Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();// depalce le node UI

        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBlueprint.upgradeCost + " $";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "<i>already done</i>";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "+" + target.turretBlueprint.GetSellAmount() + "$";
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
