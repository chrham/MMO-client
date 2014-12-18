using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour
{
	public static InputField Username;

    // Use this for initialization
    void Start()
    {
        Debug.Log("loaded");
		Connection.Establish();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void ClickLogin()
	{
		SendLoginInfo();
	}

	public static void SendLoginInfo()
	{
		Connection.sendMessage(Messages.LOGIN);
		//Debug.Log(Username.text);
		//Connection.sendMessage(Messages.LOGIN, Username.text);
	}
}