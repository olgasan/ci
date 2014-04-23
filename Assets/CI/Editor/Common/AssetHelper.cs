using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class AssetHelper
{
	private const string ASSET_PATH = "Config/Resources";
	private const string ASSET_EXTENSION = ".asset";

	public static void CreateAsset (string assetName, ScriptableObject instance)
	{
		string path = Application.dataPath + "/" + ASSET_PATH;
		
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
		
		string assetPath = "Assets/" + ASSET_PATH + "/" + assetName + ASSET_EXTENSION;
		AssetDatabase.CreateAsset(instance, assetPath);
	}
}
