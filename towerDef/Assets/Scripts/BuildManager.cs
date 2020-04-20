
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


    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBlueprint turretToBuild; //de base vide

    public bool canBuild { get { return turretToBuild != null; } } //récupère une information, le turret to build, can build est vrai si y a un truc dans turret to build

    public void buildTurretOn(Node node)
    {

        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        //le joueur a assez d argent
        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
