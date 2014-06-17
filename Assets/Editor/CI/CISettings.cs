using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class CISettings : ScriptableObject
{
	public const string ASSET_NAME = "CISettings";

	[SerializeField]
	private string appName = "myAppName";

	[SerializeField]
	private CIAndroidKeystoreConfig keystoreConfig;

	private static CISettings instance;
	
	public static CISettings Instance
	{
		#if UNITY_EDITOR
		set { instance  = value; }
		#endif
		get
		{
			if (instance == null)
				instance = Resources.Load (ASSET_NAME) as CISettings;
			
			return instance;
		}
	}

	public static string AppName 
	{
		get { return Instance.appName; }
	}

	public static CIAndroidKeystoreConfig KeystoreConfig 
	{
		get { return Instance.keystoreConfig; }
	}
}
