using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor, placedTurret;
    public Vector3 positionOffset;

    public GameObject turret;

    private Renderer rend;
    private Color startColor;
    private BuildManger buildManager;

    void Start()
    {
        buildManager = BuildManger.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            HandleInput(Input.mousePosition);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            HandleInput(Input.GetTouch(0).position);
    }

    void HandleInput(Vector3 screenPosition)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform != transform)
                return;

            if (!buildManager.canBuild)
                return;

            if (turret != null)
            {
                Debug.Log("Can't build here!");

                return;
            }

            buildManager.BuildTurretOn(this);
        }
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter()
    {
        if (Application.isMobilePlatform) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.canBuild) return;

        if (PlayerStat.money < BuildManger.instance.turretToBuild.cost)
        {
          rend.material.color = placedTurret;

        }
        else
        {
           rend.material.color = hoverColor;

        }
    }

    void OnMouseExit()
    {
        if (Application.isMobilePlatform) return;
        rend.material.color = startColor;
    }
}
