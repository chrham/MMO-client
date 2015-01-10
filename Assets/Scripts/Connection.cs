using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using System.Linq;
using System.Threading;
using UnityEditor;

public class Connection : MonoBehaviour
{
	static string SERVER_IP = "127.0.0.1";
	static int SERVER_PORT = 8888;

	static TcpClient clientSocket = new System.Net.Sockets.TcpClient();

	public static string characterList;

	public static void establish()
	{
		clientSocket.Connect(SERVER_IP, SERVER_PORT);
	}

	public static void OnReceiveServerMessage(int message, params object[] parameters)
	{
		switch(message)
		{
			case Messages.LOGIN:
			{
				if(Convert.ToInt32(parameters[0]) == 0)
				{
					EditorUtility.DisplayDialog("Login Failed", "Your account information was invalid. Please check it and try again.", "Close");
				}
				else
				{
					characterList = parameters[1].ToString();

					Application.LoadLevel("CharacterSelection");
				}

				break;
			}

			case Messages.LOADCHARACTER:
			{
				break;
			}
		}
	}

	public static void sendMessage(int message, params object[] parameters)
	{
		if (clientSocket.Connected)
		{
			try
			{
				NetworkStream serverStream = clientSocket.GetStream();

				string sendingMessage = message + ";" + String.Join(";", (from o in parameters select o.ToString()).ToArray());
				byte[] outStream = System.Text.Encoding.ASCII.GetBytes(sendingMessage + "$");
				serverStream.Write(outStream, 0, outStream.Length);
				serverStream.Flush();

				byte[] inStream = new byte[505196];
				clientSocket.GetStream().Read(inStream, 0, clientSocket.ReceiveBufferSize);
				
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

	public void OnApplicationQuit()
	{
		clientSocket.Close();
	}
}