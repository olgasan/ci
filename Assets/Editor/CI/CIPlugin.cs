using UnityEngine;
using UnityEditor;

public class CIPlugin
{
	[MenuItem ("Tools/CI/Package Core", false, 22)]

	public static void PackageCore ()
	{
		PluginPackager packager = new PluginPackager ();
		
		string[] assetPaths = new string[]
		{
			"Assets/Editor/CI/CIBuilder.cs",
			"Assets/Editor/CI/CIEditor.cs",
			"Assets/Editor/CI/CISettings.cs",
			"Assets/Editor/CI/CISettingsEditor.cs",
		};
		
		packager.Pack (assetPaths, "/ci-core.unitypackage");
	}

	[MenuItem ("Tools/CI/Package with ServerSettings", false, 22)]
	public static void PackageServer ()
	{
		PluginPackager packager = new PluginPackager ();
		
		string[] assetPaths = new string[]
		{
			"Assets/Editor/CI",
			"Assets/Plugins/CI",
		};
		
		packager.Pack (assetPaths, "/ci-with-backend.unitypackage");
	}
}
