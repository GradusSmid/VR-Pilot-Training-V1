using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOutline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Outline")
        {
            Debug.Log("woah");
            other.gameObject.GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Outline")
        {
            Debug.Log("woah");
            other.gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
