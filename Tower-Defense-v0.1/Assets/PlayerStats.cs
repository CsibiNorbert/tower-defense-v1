using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // This should be accessible to other components
    // This will carry on from one scene to another
    public static int money;
    public int startMoney = 350;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
