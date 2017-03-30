using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class ItemLoading : MonoBehaviour
{

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private ItemContaining itemCollection;
    public Text trigger, grip, touch, current;
    private int counter = 0;
    private bool languageChinese = true;

    // Use this for initialization
    void Start()
    {      
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        itemCollection = ItemContaining.Load(Path.Combine(Application.dataPath, "Resources/languages.xml"));

        //InvokeRepeating("TimerTime", 2, 3);    

        Debug.Log("Counter");
        print("DEbUB?");
        ChangeLanguage();
    }


    private void Update()
    {
        if (controller.GetPressDown(gripButton))
        {
            ChangeLanguage();
        }
       

    }

    public void ChangeLanguage()
    {
        grip.text = itemCollection.languagess[counter].gripButton;
        trigger.text = itemCollection.languagess[counter].triggerButton;
        current.text = itemCollection.languagess[counter].currentLanguage;
        touch.text = itemCollection.languagess[counter].touchPad;

        if(counter == itemCollection.languagess.Count -1)
        {
            counter = 0;
        }
        else
        {
            counter++;
        }
        Debug.Log("Counter: " +counter );

        //languageChinese = false;
    } 

    /*
    public void ChangeToEnglish()
    {
        Debug.Log("ENGLISH?");
        grip.text = itemCollection.languagess[1].gripButton;
        trigger.text = itemCollection.languagess[1].triggerButton;
        current.text = itemCollection.languagess[1].currentLanguage;
        touch.text = itemCollection.languagess[1].touchPad;

        languageChinese = true;

    }
    */











    /*
    public void ButtonTEST()
    {
        languageChinese = !languageChinese;
    }
    */


    /*
    void TimerTime()
    {
        Debug.Log("TimerTime");

        if (counter < itemCollection.AllDialogues[0].texten.Count)
        {
            current.text = itemCollection.AllDialogues[0].texten[counter];
            counter++;
        }
        else
        {
            CancelInvoke("TimerTime");
            textManager.DestroyXMLCanvas();
        }

    }

    public void Button()
    {
        itemCollection.AllDialogues[0].id = 2;
        //if counter is the same number as texten.Count, then destroy the given object
        if (counter == itemCollection.AllDialogues[0].texten.Count)
        {
        //Destroy(test);
        }
       


        grip.text = itemCollection.AllDialogues[0].texten[counter];
        //infoText.text = itemCollection.AllDialogues[0].texten[counter];
        counter++;
    }
    */

}








