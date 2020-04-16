using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    private Color startColor;
    private GameObject turret;

    public Vector3 positionOffSet; 

    private Renderer rend;

    private BuildManager buildManager;

    private void Start()//les fonction start OnmouseEnter, ect... (les fonciton en bleu) sont des fonction call back elle sont preconnu de unity
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;//recup la couleur de base

        buildManager = BuildManager.instance; // economie de ressource
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // verifié qu'il n y a rien au dessus (le canvas par exemple)
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("nop");
            return; //important pour quitter le script
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffSet, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // verifié qu'il n y a rien au dessus (le canvas par exemple)
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
