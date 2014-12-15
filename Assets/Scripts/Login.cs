using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour
{
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
}