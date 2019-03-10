using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {
	
	private static Utils instance;
	public static Utils Instance()
	{
		if (instance != null)
		{
			return instance;
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
		if(GetFloat(Constants.BestTime)<value)
		{
			SetFloat(Constants.BestTime, value);
		}
	}
}
