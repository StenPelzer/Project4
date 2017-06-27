using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    // Use this for initialization

    void Start () {


    }

    public void SaveUsername()
    {
        GameObject nickname  = GameObject.Find("NicknameInput");
        InputField inputFieldCo = nickname.GetComponent<InputField>();
        Debug.Log(inputFieldCo.text);
        Application.LoadLevel(0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
