using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControls : MonoBehaviour
{
    public Animator animatorSwitch;
    public bool isOn;

    private float delay = 1.0f;
    private float timePassed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animatorSwitch.SetBool("IsOn", isOn);
    }

    public bool GetSwitchState()
    {
        return isOn;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (Time.time - timePassed > delay)
                {
                    isOn = !(isOn);
                    timePassed = Time.time;
                }
            }
        }
    }
}
