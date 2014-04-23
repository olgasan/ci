using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class CISettingsEditor
{
	private static CISettings ObjInstance
	{
		get
		{
			if (CISettings.Instance == null)
			{
				CISettings.Instance = ScriptableObject.CreateInstance<CISettings>();
				AssetHelper.CreateAsset (CISettings.ASSET_NAME, CISettings.Instance);
			}
			
			return CISettings.Instance;
		}
	}

	[MenuItem("Config/CI Settings")]
	public static void Edit()
	{
		Selection.activeObject = ObjInstance;
	}
}