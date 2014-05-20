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
	
	private static void PerformBuild ()
	{
		BuildTarget platform = ConvertToEnum <BuildTarget> (CommandLineReader.GetCustomArgument("Platform"));
		ServerEnvironment environment = ConvertToEnum <ServerEnvironment> (CommandLineReader.GetCustomArgument("Environment"));
		
		DoBuildWithParameters (platform, environment);
	}
	
	private static void DoBuildWithParameters (BuildTarget platform, ServerEnvironment environment)
	{
		ServerSettingsEditor.SwitchTo (environment);
		string filepath = CIBuilder.GetBuildFilepath (platform, environment.ToString());
		CIBuilder.DoBuild (platform, filepath);
	}
	
	private static T ConvertToEnum <T> (string str)
	{
		T parsedEnum = default (T);
		
		try 
		{
			parsedEnum = (T) Enum.Parse(typeof(T), str);        
		}
		catch (System.ArgumentException) 
		{
			Debug.Log (string.Format ("ERROR: '{0}' is not a member of the enumeration.", str));
		}
		
		return parsedEnum;
	}
}