﻿using UnityEngine;

public class GameController : Timer {
    [SerializeField]
    private float gameSpeedDelay = 5f;
    [SerializeField]
    private float gameSpeedStep = 2f;
    [SerializeField]
    private GameObject pauseCanvas;

    private float gameSpeed;
    public bool hasGameStarted { get; set; }
    public bool isGameOver { get; set; }
    private AudioManager audioManager;

    // Use this for initialization
    override public void Start() {
        // if coming from pause
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        // set initial values
        gameSpeed = 1;
        timeOut = gameSpeedDelay;
        timeLeft = timeOut;
        // TMP
        hasGameStarted = true;
        audioManager = AudioManager.Instance;
        audioManager.PlayGameMusic();
    }

    public override void Callback() {
        gameSpeed += gameSpeedStep;
    }

    public override bool DoCycle() {
        return hasGameStarted;
    }

    public float GameSpeed() {
        return gameSpeed;
    }

    public void Pause() {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        audioManager.PauseGameMusic();
    }

    public void Play() {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        audioManager.ResumeGameMusic();
    }

    public void Exit() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main_menu");
    }

    public void MenuClickSFX() {
        audioManager.PlayMenuSFX();
        audioManager.ToggleMute();
    }
}
