using UnityEngine;
using UnityEditor;

public class CIBackendEditor 
{
	[MenuItem ("Tools/CI/Perform iOS - Dev")]
	private static void PerformIOSBuildDev ()
	{
		ServerSettingsEditor.SwitchTo (ServerEnvironment.Development);
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.iPhone, ServerEnvironment.Development.ToString());
		CIBuilder.DoBuild (BuildTarget.iPhone, filepath);
	}
	
	[MenuItem ("Tools/CI/Perform - iOS Test")]
	private static void PerformIOSBuildTest ()
	{
		ServerSettingsEditor.SwitchTo (ServerEnvironment.Testing);
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.iPhone, ServerEnvironment.Testing.ToString());
		CIBuilder.DoBuild (BuildTarget.iPhone, filepath);
	}
	
	[MenuItem ("Tools/CI/Perform Android - Dev")]
	private static void PerformAndroidBuildDev ()
	{
		ServerSettingsEditor.SwitchTo (ServerEnvironment.Development);
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.Android, ServerEnvironment.Development.ToString());
		CIBuilder.DoBuild (BuildTarget.Android, filepath);
	}
	
	[MenuItem ("Tools/CI/Perform Android - Test")]
	private static void PerformAndroidBuildTest ()
	{
		ServerSettingsEditor.SwitchTo (ServerEnvironment.Testing);
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.Android, ServerEnvironment.Testing.ToString());
		CIBuilder.DoBuild (BuildTarget.Android, filepath);
	}
}