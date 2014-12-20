using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour
{
	public InputField username;
	public InputField password;

    // Use this for initialization
    void Start()
    {
        Debug.Log("loaded");

		Connection.establish();
    }

	public void ClickLogin()
	{
		Connection.sendMessage(Messages.LOGIN, username.text, password.text);
	}
}