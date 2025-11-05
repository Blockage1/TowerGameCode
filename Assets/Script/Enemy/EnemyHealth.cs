using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image healthSprite;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        healthSprite.transform.rotation = Quaternion.LookRotation( healthSprite.transform.position - cam.transform.position);
    }
}
