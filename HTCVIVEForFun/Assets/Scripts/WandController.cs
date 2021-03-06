﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    HashSet<InteractableItems> objectsHoveringOver = new HashSet<InteractableItems>();
    //A HashSet They are basically one half of a dictionary, the key half.
    //So there's no associated array of values, but we can check to see if an element exists in the set in constant time thanks to hash functions. 
    //You can't say "give me a random element from this hash set" or anything* but they're very useful when all you care about is "does this set contain element x" 
    //and you want to check thousands of elements without the overhead over linear searching.

    private InteractableItems closestItem;
    private InteractableItems interactingItem;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }


        if (controller.GetPressDown(triggerButton))
        {
            float minDistance = float.MaxValue;

            float distance;
            //Debug.Log("FixedUpdater: objectsHoveringOver.length: " + objectsHoveringOver.Count);
            foreach (InteractableItems item in objectsHoveringOver)
            {
               // Debug.Log("Update :: objectHoveringOver :: item: " + item );
                distance = (item.transform.position - transform.position).sqrMagnitude;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestItem = item;
                }

                
            }

            interactingItem = closestItem;
            closestItem = null;

            if (interactingItem)
            {
                if (interactingItem.IsInteracting())
                {
                    interactingItem.EndInteraction(this);
                }

                interactingItem.BeginInteraction(this);
            }
        }

        if (controller.GetPressUp(triggerButton) && interactingItem != null)
        {
           // Debug.Log("WandController :: FixedUpdate : GetPressUp: " + interactingItem);
            interactingItem.EndInteraction(this);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        InteractableItems collidedItem = collider.GetComponent<InteractableItems>();
        //Debug.Log("We are in the trigger :: collidedItem: " + collidedItem );
        if (collidedItem)
        {
            
            objectsHoveringOver.Add(collidedItem);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //Debug.Log("We are out of the trigger");
        InteractableItems collidedItem = collider.GetComponent<InteractableItems>();
        if (collidedItem)
        {
            //Debug.Log("We are out of the trigger: collidedItem: " + collidedItem );
            objectsHoveringOver.Remove(collidedItem);
        }
        //Debug.Log("We are out of the trigger: objectsHoveringOver.length: " + objectsHoveringOver.Count);
    }
}
