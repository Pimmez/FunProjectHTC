using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsAutomatic : MonoBehaviour {

    [SerializeField] GameObject door, button;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip; 
    private bool turn;
    [SerializeField] private float doorAngle;
    public float smooth = 2F;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(turn)
        {
            var target = Quaternion.Euler(0, doorAngle, 0);
            // Dampen towards the target rotation
            door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, target,
            Time.deltaTime * smooth);
            GetComponent<Collider>().enabled = false;
            //this.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
     
        if(other.gameObject.tag == "Player")
        {
            turn = true;
            Debug.Log("Trigger tracked");
            //door.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time * speed);
            source.PlayOneShot(clip, 1);  
            //GetComponent<Renderer>().material.shader = Shader.Find("Custom/Outline");
            //this.enabled = false;
        }
        if(other.gameObject.tag == "Key" && this.gameObject.tag == "KeyHole")
        {
            turn = true;
            Debug.Log("Trigger tracked");
            //door.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time * speed);
            source.PlayOneShot(clip, 1);
        }

    }
}
