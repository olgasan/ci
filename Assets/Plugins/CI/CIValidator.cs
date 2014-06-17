using UnityEngine;

public class CIValidator
{
	private bool handleErrorsAsException;

	public CIValidator (bool handleErrorsAsException)
	{
		this.handleErrorsAsException = handleErrorsAsException;
	}

	public bool IsValidConfiguration (CIBuildDescriptor descriptor)
	{
		bool isValid = true;

		if (isValid)
			isValid = ValidatePlatform (descriptor.platform);

		if (isValid)
			isValid = ValidateServerEnvironment (descriptor.platform, descriptor.serverEnvironment);

		if (isValid)
			isValid = ValidateVersion (descriptor.version);

		return isValid;
	}

	private bool ValidatePlatform (RuntimePlatform platform)
	{
		bool isValid = (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer);

		if (!isValid)
		{
			HandleError (string.Format ("The '{0}' platform is not supported. Expected '{1}' or '{2}'", platform, RuntimePlatform.IPhonePlayer, RuntimePlatform.Android));
		}

		return isValid;
	}

	private bool ValidateServerEnvironment (RuntimePlatform platform, ServerEnvironment serverEnvironment)
	{
		bool isValid = serverEnvironment != ServerEnvironment.Local;

		if (!isValid)
		{
			HandleError (string.Format ("The '{0}' environment is not valid for the '{1}' platform", serverEnvironment, platform));
		}

		return isValid;
	}

	private bool ValidateVersion (string version)
	{
		bool isValid = !string.IsNullOrEmpty (version);

		if (!isValid)
			HandleError ("Version cannot be null or empty");

		return isValid;
	}

	private void HandleError (string error)
	{
		if (handleErrorsAsException)
			throw new System.NotSupportedException (error);
	}
}
