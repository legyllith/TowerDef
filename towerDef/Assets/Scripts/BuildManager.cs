
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance; //il faut faire en sorte qu il y a toujorus q'un seul build manager

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a déjà un BuildManager dans la scène !");
            return;
        }
        instance = this;
    }
    #endregion


    public GameObject buildEffect;

    private TurretBlueprint turretToBuild; //de base vide
    private Node SelectedNode;

    public NodeUi nodeUI;

    public bool canBuild { get { return turretToBuild != null; } } //récupère une information, le turret to build, can build est vrai si y a un truc dans turret to build
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } } //verifie l'argent du joueur par apport au cout


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {
        if(node == SelectedNode)
        {
            DeselectNode();
            return;
        }
        SelectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }

}
