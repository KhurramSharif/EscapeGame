using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    private static Utils _instance;

    private void Start()
    {
        _instance = this;
    }

    public static Utils Instance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        else
        {
            Debug.Log("Utils Not Inetilized....");
        }

        return null;
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }


    public void UpdateBestTime(float value)
    {
        try
        {
            if (GetFloat(Constants.BestTime) < value)
            {
            }
            else
            {
                SetFloat(Constants.BestTime, value);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}