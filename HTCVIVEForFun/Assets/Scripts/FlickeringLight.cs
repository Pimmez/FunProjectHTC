using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {
 
    [SerializeField] private Light light;
    [SerializeField]
    private float flicker;
    // Update is called once per frame
    void Update()
    {
        if (Random.value > flicker) //a random chance
        {
            if (light.enabled == true) //if the light is on...
            {
                light.enabled = false; //turn it off
            }
            else
            {
                light.enabled = true; //turn it on
            }
        }
    }
}
