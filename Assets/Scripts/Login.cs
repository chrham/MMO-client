using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class Login : MonoBehaviour
{
	public InputField username;
	public InputField password;

    void Start()
    {
        try
		{
			Connection.establish();
		}
		catch
		{
			EditorUtility.DisplayDialog("Failed to connect", "We were not able to connect to the server. Please try again later.", "Ok");
		}
    }

	public void ClickLogin()
	{
		Connection.sendMessage(Messages.LOGIN, username.text, password.text);
	}
}