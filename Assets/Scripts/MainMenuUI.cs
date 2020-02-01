using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button startButton;
    private void Awake() {
        startButton.GetComponent<Button>().onClick.AddListener(StartGameClick);
    }

    void StartGameClick() {    
        Debug.Log("Click on start game");
        Loader.Load(Loader.Scene.PlayScene);
    }
}
