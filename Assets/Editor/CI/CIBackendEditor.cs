using UnityEngine;
using UnityEditor;
using System;

public class CIBackendEditor 
{
	private static void DoBuildWithParameters (BuildTarget platform, ServerEnvironment environment, Action<BuildTarget> preBuildOperations)
	{
		if (preBuildOperations != null)
			preBuildOperations (platform);

		ServerSettingsEditor.SwitchTo (environment);
		string filepath = CIBuilder.GetBuildFilepath (platform, environment.ToString());
		CIBuilder.DoBuild (platform, filepath);
	}

	private static void DoBuildWithParameters (BuildTarget platform, ServerEnvironment environment)
	{
		DoBuildWithParameters (platform, environment, null);
	}

	private static void PerformBuild ()
	{
		BuildTarget platform = ParseEnum <BuildTarget> (CommandLineReader.GetCustomArgument("Platform"));
		ServerEnvironment environment = ParseEnum <ServerEnvironment> (CommandLineReader.GetCustomArgument("Environment"));
		DoBuildWithParameters (platform, environment, CheckVersionNumber);
	}

	[MenuItem ("Tools/CI/Perform iOS - Dev", false, 30)]
	private static void PerformIOSBuildDev ()
	{
		DoBuildWithParameters (BuildTarget.iPhone, ServerEnvironment.Development);
	}

	[MenuItem ("Tools/CI/Perform iOS - Test", false, 30)]
	private static void PerformIOSBuildTest ()
	{
		DoBuildWithParameters (BuildTarget.iPhone, ServerEnvironment.Testing);
	}

	[MenuItem ("Tools/CI/Perform Android - Dev", false, 50)]
	private static void PerformAndroidBuildDev ()
	{
		DoBuildWithParameters (BuildTarget.Android, ServerEnvironment.Development);
	}
	
	[MenuItem ("Tools/CI/Perform Android - Test", false, 50)]
	private static void PerformAndroidBuildTest ()
	{
		DoBuildWithParameters (BuildTarget.Android, ServerEnvironment.Testing);
	}

	private static void CheckVersionNumber (BuildTarget platform)
	{
		string versionNumber = CommandLineReader.GetCustomArgument("Version");

		if (!string.IsNullOrEmpty (versionNumber))
		{
			PlayerSettings.bundleVersion = versionNumber;
		}
	}

	private static T ParseEnum <T> (string str)
	{
		T value = default (T);

		try
		{
			value = (T) Enum.Parse(typeof(T), str);
		}
		catch (ArgumentException)
		{
			Debug.Log (string.Format ("ERROR: {0} is not an underlying value of the enumeration.", str));
		}

		return value;
	}
}