using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    private Color startColor;
    private GameObject turret;

    public Vector3 positionOffSet; 

    private Renderer rend;

    private void Start()//les fonction start OnmouseEnter, ect... (les fonciton en bleu) sont des fonction call back elle sont preconnu de unity
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;//recup la couleur de base
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("nop");
            return; //important pour quitter le script
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffSet, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
