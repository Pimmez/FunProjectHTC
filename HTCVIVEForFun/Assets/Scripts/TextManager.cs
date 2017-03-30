using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public Text randomText;
    [SerializeField] private GameObject XMLCanvas, cam;
    [SerializeField] private Vector3 position;
    private bool place;
    public Transform camRotation;

    private void Update()
    {
        //Vector3 camRotation = cam.transform.position - XMLCanvas.transform.position;
        //XMLCanvas.transform.rotation = Quaternion.LookRotation(camRotation);
        if(place)
        {
            XMLCanvas.transform.LookAt(camRotation);
        }
       
    }

    public void PlaceXMLCanvas()
    {
        place = true;
        //Instantiate(XMLCanvas, position, XMLCanvas.transform.rotation);
    }

    public void DestroyXMLCanvas()
    {
        Destroy(XMLCanvas,1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlaceXMLCanvas();
        }
    }
}
