using UnityEngine;
using UnityEditor;

public class CIMenus : MonoBehaviour 
{
	private const string PERFORM = "Tools/CI/Perform ";
	private const string IOS = "iOS - ";
	private const string ANDROID = "Android - ";
	private const string DEV = "Dev";
	private const string TEST = "Test";

	[MenuItem (PERFORM + IOS + DEV, false, 30)]
	private static void PerformIOSBuildDev ()
	{
		CIBackendEditor.DoBuildWithParameters (BuildTarget.iPhone, ServerEnvironment.Development);
	}
	
	[MenuItem (PERFORM + IOS + TEST, false, 30)]
	private static void PerformIOSBuildTest ()
	{
		CIBackendEditor.DoBuildWithParameters (BuildTarget.iPhone, ServerEnvironment.Testing);
	}
	
	[MenuItem (PERFORM + ANDROID + DEV, false, 50)]
	private static void PerformAndroidBuildDev ()
	{
		CIBackendEditor.DoBuildWithParameters (BuildTarget.Android, ServerEnvironment.Development);
	}
	
	[MenuItem (PERFORM + ANDROID + TEST, false, 50)]
	private static void PerformAndroidBuildTest ()
	{
		CIBackendEditor.DoBuildWithParameters (BuildTarget.Android, ServerEnvironment.Testing);
	}

	#region validate

	[MenuItem (PERFORM + IOS + DEV, true)]
	[MenuItem (PERFORM + IOS + TEST, true)]
	private static bool IsInIOS ()
	{
		return EditorUserBuildSettings.selectedBuildTargetGroup == BuildTargetGroup.iPhone;
	}

	[MenuItem (PERFORM + ANDROID + DEV, true)]
	[MenuItem (PERFORM + ANDROID + TEST, true)]
	private static bool IsInAndroid ()
	{
		return EditorUserBuildSettings.selectedBuildTargetGroup == BuildTargetGroup.Android;
	}

	#endregion
}
