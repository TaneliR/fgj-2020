using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenUI : MonoBehaviour
{
    public Button playButton;
    private void Awake() {
        playButton.GetComponent<Button>().onClick.AddListener(StartGameClick);
    }

    void StartGameClick() {    
        Debug.Log("Click on start game");
        Loader.Load(Loader.Scene.GameScene);
    }
}
