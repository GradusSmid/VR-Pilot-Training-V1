using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    private HingeJoint _joint;
    public bool startAsOn = true;
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
        float Rotation;
        
        if (transform.localEulerAngles.x <= 180f)
            Rotation = transform.localEulerAngles.x;
        else
            Rotation = transform.localEulerAngles.x - 360f;
        transform.Rotate(new Vector3(0, 0, 0), Space.Self);
        if (Rotation >= _joint.limits.max)
        {
            onOff.Invoke();
        }

        if (Rotation <= _joint.limits.min )
        {
            onOn.Invoke();
        }
    }
}
