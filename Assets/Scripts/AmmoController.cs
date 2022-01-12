using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public static AmmoController instance;

    public int currentAmmo, maxAmmo;

    private void Awake()
    {
        instance = this; 
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        UIController.instance.ammoCounter.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
