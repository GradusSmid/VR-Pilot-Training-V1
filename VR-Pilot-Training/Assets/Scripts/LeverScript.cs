using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    //Vector3 mousePos;
    private Vector3 screenPoint;
    private Vector3 offset;
    float angleMin;
    float angleStart;
    float angleMax;
    float angleStop;
    [SerializeField] [Range(2, 10)] int totalPoints = 2;
    float spaceInbetween;
    float[] snapPoints;
    float currentXRotation;
    float currentZRotation;
    float nearest;
    public bool useZaxis = true;
    int indexNumber;
    public GameObject lever;

    public List<UnityEvent> positions;

    private void Start()
    {
        currentXRotation = lever.gameObject.transform.localEulerAngles.x;
        currentZRotation = lever.gameObject.transform.localEulerAngles.z;
        angleMin = lever.GetComponent<HingeJoint>().limits.min;
        angleMax = lever.GetComponent<HingeJoint>().limits.max;
        if (useZaxis == true)
        {
            angleStart = currentZRotation + angleMin;
            angleStop = currentZRotation + angleMax;
        } else
        {
            angleStart = currentXRotation + angleMin;
            angleStop = currentXRotation + angleMax;
        }


        //Debug.Log("angleStart" + angleStart);
        //Debug.Log("angleStop" + angleStop);


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
        //Debug.Log("Snappoint 1: " + snapPoints[0] + "Snappoint 2: " + snapPoints[1] + "Snappoint 3: " + snapPoints[2]);
        if (useZaxis == true)
        {
            var nearest = snapPoints.OrderBy(z => Mathf.Abs(z - lever.gameObject.transform.localEulerAngles.z)).First();
            var qr = Quaternion.Euler(0, nearest, 0);
            indexNumber = System.Array.IndexOf(snapPoints, nearest);
            positions[indexNumber].Invoke();
        } else
        {
            //==========================
            var nearest = snapPoints.OrderBy(x => Mathf.Abs(x - lever.gameObject.transform.localEulerAngles.x)).First();
            var qr = Quaternion.Euler(0, nearest, 0);
            indexNumber = System.Array.IndexOf(snapPoints, nearest);
            positions[indexNumber].Invoke();
            //=========================
        }
    }

    public void OnReleaseGrab()
    {
        if (useZaxis == true)
        {
            var nearest = snapPoints.OrderBy(z => Mathf.Abs(z - lever.gameObject.transform.localEulerAngles.z)).First();
            var qr = Quaternion.Euler(0, nearest, 0);
            indexNumber = System.Array.IndexOf(snapPoints, nearest);
            Debug.Log("indexNumber" + indexNumber);
            positions[indexNumber].Invoke();
        } else
        {
            //=========================
            var nearest = snapPoints.OrderBy(x => Mathf.Abs(x - lever.gameObject.transform.localEulerAngles.x)).First();
            var qr = Quaternion.Euler(0, nearest, 0);
            indexNumber = System.Array.IndexOf(snapPoints, nearest);
            Debug.Log("indexNumber" + indexNumber);
            positions[indexNumber].Invoke();
            //==========================
        }
    }

}
