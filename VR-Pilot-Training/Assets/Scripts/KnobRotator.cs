using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;
using UnityEngine;

public class KnobRotator : MonoBehaviour
{
    private Vector3 offset;
    float angleMin;
    float angleStart;
    float angleMax;
    float angleStop;
    [SerializeField] [Range(2, 10)] int totalPoints = 2;
    float spaceInbetween;
    float[] snapPoints;
    float currentRotation;
    float nearest;
    int indexNumber;

    public List<UnityEvent> positions;

    private void Start()
    {
        currentRotation = this.gameObject.transform.localEulerAngles.y;
        angleMin = GetComponent<HingeJoint>().limits.min;
        angleMax = GetComponent<HingeJoint>().limits.max;
        angleStart = currentRotation + angleMin;
        angleStop = currentRotation + angleMax;

        snapPoints = new float[totalPoints];      

        spaceInbetween = angleStop - angleStart;
        float tempPoint = spaceInbetween / (totalPoints - 1);
        float distancePerPoint = tempPoint;

        snapPoints[0] = angleStart;
        for (int i = 1; i < totalPoints; i++)
        {
            snapPoints[i] = angleStart + tempPoint;
            tempPoint = tempPoint + distancePerPoint;
        }
        //==========================
        var nearest = snapPoints.OrderBy(x => Mathf.Abs(x - this.gameObject.transform.localEulerAngles.y)).First();
        var qr = Quaternion.Euler(10, nearest, 10);
        indexNumber = System.Array.IndexOf(snapPoints, nearest);
        Debug.Log("indexNumber" + indexNumber);
        positions[indexNumber].Invoke();
        transform.rotation = qr;
        //==========================
    }

    public void OnReleaseGrab()
    {
        var nearest = snapPoints.OrderBy(x => Mathf.Abs(x - this.gameObject.transform.localEulerAngles.y)).First();
        var qr = Quaternion.Euler(10, nearest, 10);
        indexNumber = System.Array.IndexOf(snapPoints, nearest);
        positions[indexNumber].Invoke();
        transform.rotation = qr;
    }

}
