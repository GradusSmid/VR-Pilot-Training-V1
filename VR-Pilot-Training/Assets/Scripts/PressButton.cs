using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressButton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    [SerializeField] private bool canBePressed;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && Getvalue() + threshold >= 1 && canBePressed == true)
        {
            Pressed();
            canBePressed = false;    
        }
        if (Getvalue() - threshold <= 0)
        {
            canBePressed = true;
        }
        if (_isPressed && Getvalue() + threshold >= 1 && canBePressed == true)
        {
            Released();
            canBePressed = false;
        }
    }

    private float Getvalue()
    {
        float value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if(Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }
    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
