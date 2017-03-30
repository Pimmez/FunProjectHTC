using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string chooselevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Door")
        {
            SceneManager.LoadScene(chooselevel);
        }
        if(this.gameObject.tag == "Stop" && other.gameObject.tag == "Player")
        {
            Application.Quit();
        }
    }
  
}
