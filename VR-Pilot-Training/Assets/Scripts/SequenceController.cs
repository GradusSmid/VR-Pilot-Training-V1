using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    /*Create costum sequence. 
     * (Button 1 on pos 3, button 2 on pos 1, button 3 on pos 4)
     * Knob rotator, leverscript, and button scripts trigger public voids in this script.
     * On their side we can determine which position is correct by activating a public void here.
     * This needs a number variable number of Unity events " public List<UnityEvent> sequence; "
     * If all are correct it's green lights.
    */

    public List<UnityEvent> sequence;
    [SerializeField] [Range(1, 10)] int stepsToComplete = 4;
    int stepsCorrect = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stepsCorrect >+ stepsToComplete)
        {
            Debug.Log("Training complete");
        }
    }

    //Need a >Efficient< way so you can't repeat a step to complete. 
    public void stepOne()
    {
        //if stepOneCheck == 0, do this.
        stepsCorrect += 1;
        //After set stepOneCheck to 1.
        //Then it can only be called once, but this methos is not very pretty.
    }

    public void stepTwo()
    {
        stepsCorrect += 1;
    }

    public void stepThree()
    {
        stepsCorrect += 1;
    }

    public void stepFour()
    {
        stepsCorrect += 1;
    }
}
