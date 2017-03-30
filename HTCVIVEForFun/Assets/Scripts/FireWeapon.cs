using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour {

    private EnemyManager enemy;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject weapon;

    private void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update () {
		if(weapon.tag == "FireSword")
        {      
            particle.Play();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fire" && this.gameObject.tag == "Sword")
        {
            this.gameObject.tag = "FireSword";
        }
    }
}
