using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotations : MonoBehaviour
{

    private Vector3 rotateVector;

    public bool lockX;
    public bool lockY;
    public bool lockZ;

    [Tooltip("limit rotation between min and max of hingejoint")]public bool limitRotation;

    private float x;
    private float y;
    private float z;

    [SerializeField]private HingeJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lockX == false)
        {
            x = transform.eulerAngles.x;
        }
        else x = 0;

        if (lockY == false)
        {
            y = transform.eulerAngles.y;
            
        }
        else y = 0;

        if (lockZ == false)
        {
            z = transform.eulerAngles.z;
        }
        else z = 0;

        rotateVector = new Vector3(x, y, z);
        transform.rotation = Quaternion.Euler(rotateVector);

        if(limitRotation == true)
        {
            if (transform.eulerAngles.y >= joint.limits.max)
            {
                y = joint.limits.max;
            }
            if (transform.eulerAngles.y <= joint.limits.min)
            {
                y = joint.limits.min;
            }
        }
    }
}
