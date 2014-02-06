using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ServerConfigParameter
{
	public ServerEnvironment environment = ServerEnvironment.Development;
	public string domain = string.Empty;
}

public class ServerSettings : ScriptableObject
{
	public const string ASSET_NAME = "ServerSettings";
	
	[SerializeField]
	private ServerEnvironment currentEnvironment;
	
	[SerializeField]
	private List<ServerConfigParameter> parameters = new List<ServerConfigParameter> ();

	private static ServerSettings instance; 

	public static ServerSettings Instance 
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load (ASSET_NAME) as ServerSettings;
			}


			return instance;
		}
	}

	public ServerEnvironment CurrentEnvironment
	{
		get { return currentEnvironment; }
		#if UNITY_EDITOR
		set { currentEnvironment = value; }
		#endif
	}

	public string Domain
	{
		get
		{
			if (parameters != null)
			{
				ServerConfigParameter p = parameters.Find (delegate(ServerConfigParameter config) {
					return config.environment == this.currentEnvironment;
				});

				return p.domain;
			}

			return null;
		}
	}
}
