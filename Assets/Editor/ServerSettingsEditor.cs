using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class ServerSettingsEditor
{


	private static ServerSettings ObjInstance
	{
		get
		{
			ServerSettings instance = Resources.Load(ServerSettings.ASSET_NAME) as ServerSettings;
			if (instance == null)
			{
				instance = ScriptableObject.CreateInstance<ServerSettings>();
				AssetHelper.CreateAsset (ServerSettings.ASSET_NAME, instance);
			}

			return instance;
		}
	}
	
	[MenuItem("Config/Server Settings")]
	public static void Edit()
	{
		Selection.activeObject = ObjInstance;
	}

	public static void SwitchTo (ServerEnvironment environment)
	{
		ServerSettings.Instance.CurrentEnvironment = environment;
		EditorUtility.SetDirty(ServerSettings.Instance);
	}
}
