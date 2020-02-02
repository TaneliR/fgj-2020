using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene {
        GameScene,
        MainMenu,
        PlayScene,
        WinScene,
        LoseScene,
        Briefing,
    }
    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}
