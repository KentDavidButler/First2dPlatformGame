using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControls : MonoBehaviour
{

    public Animator animatorDoorTop;
    public Animator animatorDoorBtm;
    private bool isOpen;

    public GameObject DoorSwitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = DoorSwitch.GetComponent<SwitchControls>().GetSwitchState();
        animatorDoorTop.SetBool("IsOpenTop", isOpen);
        animatorDoorBtm.SetBool("IsOpenBtm", isOpen);
    }
}
