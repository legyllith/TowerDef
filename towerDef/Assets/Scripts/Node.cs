using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughtMoneyColor;
    private Color startColor;
    public GameObject turret;

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

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // verifié qu'il n y a rien au dessus (le canvas par exemple)
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("nop");
            return; //important pour quitter le script
        }

        buildManager.buildTurretOn(this);
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
