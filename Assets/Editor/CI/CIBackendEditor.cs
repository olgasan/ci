using UnityEngine;
using UnityEditor;
using System;

public class CIBackendEditor 
{
	[MenuItem ("Tools/CI/Perform iOS - Dev")]
	private static void PerformIOSBuildDev ()
	{
		DoBuildWithParameters (BuildTarget.iPhone, ServerEnvironment.Development);
	}
	
	[MenuItem ("Tools/CI/Perform - iOS Test")]
	private static void PerformIOSBuildTest ()
	{
		DoBuildWithParameters (BuildTarget.iPhone, ServerEnvironment.Testing);
	}
	
	[MenuItem ("Tools/CI/Perform Android - Dev")]
	private static void PerformAndroidBuildDev ()
	{
		DoBuildWithParameters (BuildTarget.Android, ServerEnvironment.Development);
	}
	
	[MenuItem ("Tools/CI/Perform Android - Test")]
	private static void PerformAndroidBuildTest ()
	{
		DoBuildWithParameters (BuildTarget.Android, ServerEnvironment.Testing);
	}

	private static void DoBuildWithParameters (BuildTarget platform, ServerEnvironment environment)
	{
		ServerSettingsEditor.SwitchTo (environment);
		string filepath = CIBuilder.GetBuildFilepath (platform, environment.ToString());
		CIBuilder.DoBuild (platform, filepath);
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
	
	private static void PerformBuild ()
	{
		BuildTarget platform = ParseEnum <BuildTarget> (CommandLineReader.GetCustomArgument("Platform"));
		ServerEnvironment environment = ParseEnum <ServerEnvironment> (CommandLineReader.GetCustomArgument("Environment"));
		DoBuildWithParameters (platform, environment);
	}
}