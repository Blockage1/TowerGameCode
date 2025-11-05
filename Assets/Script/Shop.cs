using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    BuildManger buildManger;



    private void Start()
    {
        buildManger = BuildManger.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Purchased");
        buildManger.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissleLauncher()
    {
        Debug.Log("missle Purchased");
        buildManger.SelectTurretToBuild(missileLauncher);



    }
}
