using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    private HingeJoint _joint;
    // Start is called before the first frame update

    public UnityEvent onOn, onOff;
    void Start()
    {
        _joint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float Rotation;
        if (transform.localEulerAngles.x <= 180f)
            Rotation = transform.localEulerAngles.x;
        else
            Rotation = transform.localEulerAngles.x - 360f;
        Debug.Log(Rotation);

        if (Rotation >= _joint.limits.max)
        {
            onOn.Invoke();
        }

        if (Rotation <= _joint.limits.min )
        {
            onOff.Invoke();
        }
    }
}
