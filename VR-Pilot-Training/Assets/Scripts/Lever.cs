using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    private HingeJoint _joint;
    public bool startAsOn = true;
    public bool isOn;
    // Start is called before the first frame update

    public UnityEvent onOn, onOff;
    void Start()
    {
        _joint = GetComponent<HingeJoint>();

        if (startAsOn)
        {
            onOn.Invoke();
        }
        else
        {
            onOff.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOn == false)
            {
                transform.Rotate(new Vector3(-100, 0, 0));
                isOn = true;
                onOff.Invoke();
            }

            else if (isOn == true)
            {
                transform.Rotate(new Vector3(100, 0, 0));
                isOn = false;
                onOn.Invoke();
            }

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
            {
                Debug.Log("Gefonden");
                if (isOn == false)
                {
                    transform.Rotate(new Vector3(-100, 0, 0));
                    isOn = true;
                    onOff.Invoke();
                }

                else if (isOn == true)
                {
                    transform.Rotate(new Vector3(100, 0, 0));
                    isOn = false;
                    onOn.Invoke();
                }

            }
        }
    }
}
