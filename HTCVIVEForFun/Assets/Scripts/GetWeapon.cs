using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    [SerializeField] private Transform hand;
    public List<Transform> objects = new List<Transform>();

    [SerializeField] private float grabDistance;
    private bool isAttached;
    private bool triggerButtonDown;
    private float distance;

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

	// Update is called once per frame
	void Update () {
        triggerButtonDown = controller.GetPressDown(triggerButton);

        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }
        if (triggerButtonDown && isAttached)
        {
            //Debug.Log("detachItem");
            DettachItem();
            return;

        }
        foreach (Transform item in objects)
        {
            distance = Vector3.Distance(item.transform.position, transform.position);
            if ((distance < grabDistance) && triggerButtonDown && !isAttached)
            {
                AttachItem(item);
            }
        }

    }

    public void AttachItem(Transform item)
    {
        //Debug.Log("AttachItem: " + isAttached);

        item.transform.parent = hand.transform;
        item.transform.localPosition = Vector3.zero;
        item.transform.rotation = hand.rotation;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        isAttached = true;
    }

    public void DettachItem()
    {
        foreach (Transform item in objects)
        {
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        isAttached = false;
    }

}
