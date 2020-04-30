using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughtMoneyColor;
    private Color startColor;

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;

    public Vector3 positionOffSet; 

    private Renderer rend;

    private BuildManager buildManager;

    private void Start()//les fonction start OnmouseEnter, ect... (les fonciton en bleu) sont des fonction call back elle sont preconnu de unity
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;//recup la couleur de base

        buildManager = BuildManager.instance; // economie de ressource
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Pas assez d'argent pour amélioré");
            return;
        }

        //le joueur a assez d argent
        PlayerStats.money -= turretBlueprint.upgradeCost;
        //supression de lancienne tourelle
        Destroy(turret);

        //création tourelle améliorée.
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = true;
    }

    private void buildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        //le joueur a assez d argent
        PlayerStats.money -= blueprint.cost;

        turretBlueprint = blueprint;//très important pour mettre a jour

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // verifié qu'il n y a rien au dessus (le canvas par exemple)
        {
            return;
        }
        
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return; //important pour quitter le script
        }

        if (!buildManager.canBuild)
        {
            return;
        }


        buildTurret(buildManager.GetTurretToBuild());
    }

    private void OnMouseEnter()
    { 
        if (EventSystem.current.IsPointerOverGameObject()) // verifié qu'il n y a rien au dessus (le canvas par exemple)
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughtMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
