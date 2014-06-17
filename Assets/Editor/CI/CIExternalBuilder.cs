using UnityEngine;
using System.Collections;
using System;

public class CIExternalBuilder
{
	private const string PLATFORM = "Platform";
	private const string VERSION = "Version";
	private const string SERVER_ENVIRONMENT = "ServerEnvironment";
	private const string IS_DEBUG = "IsDebug";
	private const string EXTERNAL_MOD = "ExternalMod";

	public static void PerformBuild ()
	{
		CIBuildDescriptor descriptor = new CIBuildDescriptor ();
		
		descriptor.platform = ParseEnum <RuntimePlatform> (CommandLineReader.GetCustomArgument(PLATFORM));
		descriptor.serverEnvironment = ParseEnum <ServerEnvironment> (CommandLineReader.GetCustomArgument(SERVER_ENVIRONMENT));
		descriptor.version = CommandLineReader.GetCustomArgument(VERSION);
		descriptor.isDebugBuild = CommandLineReader.GetCustomArgument(IS_DEBUG) == "true";
		descriptor.acceptExternalModifications = CommandLineReader.GetCustomArgument(EXTERNAL_MOD) == "true";
		
		CIBuilder.DoBuildWithParameters (descriptor);
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
