using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
     /* ===========================================
     * Bit spagetti, but it works. 
     * ============================================
    */

    int timer = 0;
    int score = 0;
    bool scoreDecrease = false;
    bool completed = false;
    public string sceneName;
    public GameObject myCanvas;
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

    [SerializeField] private GameObject lightstuff;

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        if (timer >= 10) // Only decrease score a bit after game has started.
        {
            scoreDecrease = true;
        }

        if (completed == false && 
            one == true &&
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
            completed = true;
            StartCoroutine(LevelComplete());
        }
    }

    //Still looking for a prettier way to achive the same result
    public void stepOne()
    {
        one = true;
    }
    public void stepOneWrong()
    {
        one = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepTwo()
    {
        //if (one == true)
        //{
            two = true;
        //}
    }
    public void stepTwoWrong()
    {
        two = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepThree()
    {
        //if (two == true)
        //{
            three = true;
        //}
    }
    public void stepThreeWrong()
    {
        three = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepFour()
    {
        //if (three == true)
        //{
            four = true;
        //}
    }
    public void stepFourWrong()
    {
        four = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepFive()
    {
        five = true;
    }
    public void stepFiveWrong()
    {
        five = false;
        if (scoreDecrease == true)
        {
            score -= 1;
        }
    }

    public void stepSix()
    {
        six = true;
    }
    public void stepSixWrong()
    {
        six = false;
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

    /*
    public void levelComplete()
    {
        Debug.Log("Level complete");
        Debug.Log("Minus points: " + score);
    }
    */
    IEnumerator LevelComplete()
    {
        lightstuff.SetActive(false);
        myCanvas.SetActive(true);
        Debug.Log("Minus points: " + score);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneName);
    }
}