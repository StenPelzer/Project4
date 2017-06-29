using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    Button myButton;
    public bool isMute;
    void Start()
    {
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(() => { onClick(); });
    }

    public void onClick()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        print("ButtonCLicked");
    }


}