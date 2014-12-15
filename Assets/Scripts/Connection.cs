using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System;

public class Connection : MonoBehaviour
{
	static string SERVER_IP = "127.0.0.1";
	static int SERVER_PORT = 8888;

	static TcpClient clientSocket = new System.Net.Sockets.TcpClient();

	// Use this for initialization
	void Start()
    {

	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

	public static void Establish()
	{
		clientSocket.Connect(SERVER_IP, SERVER_PORT);
	}

	public static void OnReceiveServerMessage(int message, params string[] parameters)
	{
		switch(message)
		{
			case Messages.LOGIN:
			{
				break;
			}
		}
	}

	public static void sendMessage(int message, params string[] parameters)
	{
		if (clientSocket.Connected)
		{
			try
			{
				NetworkStream serverStream = clientSocket.GetStream();
				
				string sendingMessage = message + ";" + String.Join(";", parameters);
				
				byte[] outStream = System.Text.Encoding.ASCII.GetBytes(sendingMessage + "$");
				serverStream.Write(outStream, 0, outStream.Length);
				serverStream.Flush();
				
				byte[] inStream = new byte[505196];
				serverStream.Read(inStream, 0, clientSocket.ReceiveBufferSize);
				
				List<string> receivedMessage = new List<string>(System.Text.Encoding.ASCII.GetString(inStream).Split(';'));
				int messageID = Convert.ToInt32(receivedMessage[0]);
				
				receivedMessage.RemoveAt(0);
				
				OnReceiveServerMessage(messageID, receivedMessage.ToArray());
			}
			catch
			{
			}
		}
	}
}