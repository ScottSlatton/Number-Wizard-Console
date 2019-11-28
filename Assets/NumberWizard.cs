using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Start is called before the first frame update

    int max = 1000;
    int min = 1;
    int guess = 500;
    void Start()
    {
        
        Debug.Log("Welcome to Number Wizard!");
        Debug.Log($"Think of a number between {min} and {max} and I'll try to guess it.");
        Debug.Log($"Tell me if your number is higher or lower than {guess}");
        Debug.Log("Press Up arrow for higher and Down arrow for lower. Press Enter if guess is correct.");
        max++;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Change guess to Max and previous guess divided by 2

            min = guess;
            guess = (max + min) / 2;
            Debug.Log($"My guess is {guess}");

        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Change guess to Min and previous guess divided by 2
            max = guess;
            guess = (max + min) / 2;
            Debug.Log($"My guess is {guess}");

        } else if (Input.GetKeyDown(KeyCode.Return))
        {
            //Prompt user for replay.
            Debug.Log("Would you like to play again?");

        }


    }
}
