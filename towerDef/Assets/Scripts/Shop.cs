using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncherTurret;
    public TurretBlueprint lazerBeamerTurret;

    private BuildManager buildManager;

    private void Start()//economise des ressource en instance le build manager au début
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncherTurret);
    }

    public void SelectLazerBeamer()
    {
        buildManager.SelectTurretToBuild(lazerBeamerTurret);
    }

}
