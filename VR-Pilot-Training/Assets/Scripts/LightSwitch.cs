using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    // Update is called once per frame

    public void startSwitch()
    {
        StartCoroutine("Switch");
    }

    IEnumerator Switch()
    {
        Debug.Log("On");
        this.GetComponent<Light>().enabled = true;

        yield return new WaitForSeconds(1f);
        Debug.Log("Off");
        this.GetComponent<Light>().enabled = false;

        yield return new WaitForSeconds(1f);
        startSwitch();
    }
}
