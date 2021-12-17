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
     * 
     * Every button has a seperate function they can call
     * If all buttons are done correct in sequence level iscomplete
     * Problems: 
     * - Has to be done in sequence, if it is wrong it has to reset.
     * - User may not be able to keep sending the correct awnser from the same button, so it has to be done with a true & false system instead of a += 1 system.
     * - Some buttons could already be on the right position
     * 
     * ========================================================================================================================
     * Bit spagetti, but should work as long as all buttons send their current position as soon as they start to this script. 
     * Especcialy if those positions are wrong.
     * ========================================================================================================================
    */

    //public List<UnityEvent> sequence;
    //[SerializeField] [Range(1, 10)] int stepsToComplete = 4;
    //int stepsCorrect = 0;
    int timer = 0;
    bool scoreDecrease = false;
    int score = 0;
    bool one = true;
    bool two = true;
    bool three = true;
    bool four = true;
    bool five = true;
    bool six = true;
    bool seven = true;
    bool eight = true;
    bool nine = true;
    bool ten = true;

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        if (timer >= 10) // Only decrease score a bit after game has started.
        {
            scoreDecrease = true;
        }

        if (one == true &&
            two == true &&
            three == true &&
            four == true &&
            five == true &&
            six == true &&
            seven == true &&
            eight == true &&
            nine == true &&
            ten == true)
        {
            levelComplete();
        }

    }

    //Still looking for a prettier way to achive the same result
    public void stepOne()
    {
        one = true;
        Debug.Log("Step 1 correct");
    }
    public void stepOneWrong()
    {
        one = false;
        Debug.Log("Step 1 WRONG!");
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepTwo()
    {
        two = true;
        Debug.Log("Step 2 correct");
    }
    public void stepTwoWrong()
    {
        two = false;
        Debug.Log("Step 2 WRONG!");
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepThree()
    {
        three = true;
        Debug.Log("Step 3 correct");
    }
    public void stepThreeWrong()
    {
        three = false;
        Debug.Log("Step 3 WRONG!");
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepFour()
    {
        four = true;
        Debug.Log("Step 4 correct");
    }
    public void stepFourWrong()
    {
        four = false;
        Debug.Log("Step 4 WRONG!");
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepFive()
    {
        five = true;
        Debug.Log("Step 5 correct");
    }
    public void stepFiveWrong()
    {
        five = false;
        Debug.Log("Step 5 WRONG!");
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepSix()
    {
        six = true;
        Debug.Log("Step 6 correct");
    }
    public void stepSixWrong()
    {
        six = false;
        Debug.Log("Step 6 WRONG!");
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepSeven()
    {
        six = true;
    }
    public void stepSevenWrong()
    {
        seven = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepEight()
    {
        eight = true;
    }
    public void stepEightWrong()
    {
        eight = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepNine()
    {
        nine = true;
    }
    public void stepNineWrong()
    {
        nine = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepTen()
    {
        ten = true;
    }
    public void stepTenWrong()
    {
        ten = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }


    public void levelComplete()
    {
        Debug.Log("Level complete");
        Debug.Log("Minus points: " + score);
    }
    /*
    public void resetSquence()
    {
        one = false;
        two = false;
        three = false;
        four = false;
        five = false;
        six = false;
        seven = false;
        eight = false;
        nine = false;
        ten = false;
    }
    */
}