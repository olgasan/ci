using UnityEngine;
using UnityEditor;

public class CIPlugin
{
	[MenuItem ("Tools/CI/Package Core", false, 10)]

	public static void PackageCore ()
	{
		PluginUtils packager = new PluginUtils ();
		
		string[] assetPaths = new string[]
		{
			"Assets/Editor/CI/CIBuilder.cs",
			"Assets/Editor/CI/CIEditor.cs",
			"Assets/Editor/CI/CISettings.cs",
			"Assets/Editor/CI/CISettingsEditor.cs",
		};
		
		packager.Pack (assetPaths, "/ci-core.unitypackage");
	}

	[MenuItem ("Tools/CI/Package with ServerSettings", false, 10)]
	public static void PackageServer ()
	{
		PluginUtils packager = new PluginUtils ();
		
		string[] assetPaths = new string[]
		{
			"Assets/Editor/CI",
			"Assets/Plugins/CI",
		};
		
		packager.Pack (assetPaths, "/ci-with-backend.unitypackage");
	}
}
