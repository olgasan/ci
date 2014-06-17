using UnityEngine;

[System.Serializable]
public class CIAndroidKeystoreConfig
{
	[SerializeField]
	private string keyaliasName;

	[SerializeField]
	private string keystorePass;

	[SerializeField]
	private string keyaliasPass;

	public string KeyaliasName 
	{
		get { return keyaliasName; }
	}

	public string KeystorePass 
	{
		get { return keystorePass; }
	}

	public string KeyaliasPass 
	{
		get { return keyaliasPass; }
	}
}
