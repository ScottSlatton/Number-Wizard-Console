using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System;

public class NumberWizard : MonoBehaviour
{
    // Start is called before the first frame update

    int max = 1000;
    int min = 1;
    int guess = 500;
    bool complete = false;
    void Start()
    {
        StartGame();
        
    }
    
    void StartGame()
    {

        max = 1000;
        min = 1;
        guess = 500;

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
            NextGuess();

        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Change guess to Min and previous guess divided by 2
            max = guess;
            NextGuess();

        } else if (Input.GetKeyDown(KeyCode.Return))
        {
            //Prompt user for replay.
            Debug.Log("I knew it!");
            Debug.Log("Press the Spacebar if you'd like to replay.");
            complete = true;

        } else if (Input.GetKeyDown(KeyCode.Space) && complete)
            {
                Utils.ClearLogConsole();
                StartGame();
            }


    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log($"Is it higher or lower than {guess}?");
    }
}


public static class Utils
{
    static MethodInfo _clearConsoleMethod;
    static MethodInfo clearConsoleMethod
    {
        get
        {
            if (_clearConsoleMethod == null)
            {
                Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
                Type logEntries = assembly.GetType("UnityEditor.LogEntries");
                _clearConsoleMethod = logEntries.GetMethod("Clear");
            }
            return _clearConsoleMethod;
        }
    }

    public static void ClearLogConsole()
    {
        clearConsoleMethod.Invoke(new object(), null);
    }
}
