using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;


    private void Start()
    {
        money =  startMoney;
    }
}
