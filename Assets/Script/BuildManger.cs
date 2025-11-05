using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildManger : MonoBehaviour
{
    public TurretBluePrint turretToBuild;

    public static BuildManger instance;


    public GameObject standardTurretPerfab;

    public GameObject missleLauncherPerfab;

    public TextMeshProUGUI enenmyValue;

    public List<Image> health;

    public int wayPointvalue;

    void Awake()
    {

        if (instance != null)
        {
            Debug.Log("Multiple");
            return;
        }
        instance = this;
         
    }

    private void Start()
    {
        wayPointvalue = 4; 
    }
    private void Update()
    {
      
        
        enenmyValue.text = PlayerStat.money.ToString();   
    }
    public bool canBuild { get { return turretToBuild != null; } } //this line is called a propertie what it does it we only allow to get something this vaibale


    public void BuildTurretOn(Node node)
    {
        if (PlayerStat.money < turretToBuild.cost)
        {
            Debug.Log("no money");

            return;
        }
        PlayerStat.money -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.perfab,node.GetBuildPosition(),Quaternion.identity);
        node.turret = turret;

        Debug.Log("turret buidd "+  PlayerStat.money);
    }
  public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
