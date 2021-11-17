﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    // This GameFlowManager has been edited to play levels from build settings in sequence, or return to the main menu.
    // DO NOT CHANGE THIS SCRIPT! You may customise the audio and message prefabs it refers to, if you want.

    [Header("Parameters")]
    private float endSceneLoadDelay = 3f;
    [Tooltip("The canvas group of the fade-to-black screen")]
    public CanvasGroup endGameFadeCanvasGroup;
    private float delayBeforeFadeToBlack = 4f;
    private float delayBeforeWinMessage = 2f;
    [Tooltip("The audio clip played upon win")]
    public AudioClip victorySound;
    [Tooltip("The message to be shown on win")]
    public GameObject WinGameMessagePrefab;

    public bool gameIsEnding { get; private set; }
    public bool ReplayScene = false;
    int nextSceneIndex;

    PlayerCharacterController m_Player;
    NotificationHUDManager m_NotificationHUDManager;
    ObjectiveManager m_ObjectiveManager;
    float m_TimeLoadEndGameScene;

    void Start()
    {
        m_Player = FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, GameFlowManager>(m_Player, this);

        m_ObjectiveManager = FindObjectOfType<ObjectiveManager>();
		DebugUtility.HandleErrorIfNullFindObject<ObjectiveManager, GameFlowManager>(m_ObjectiveManager, this);

        AudioUtility.SetMasterVolume(1);
    }

    void Update()
    {
        if (gameIsEnding)
        {
            float timeRatio = 1 - (m_TimeLoadEndGameScene - Time.time) / endSceneLoadDelay;
            endGameFadeCanvasGroup.alpha = timeRatio;

            AudioUtility.SetMasterVolume(1 - timeRatio);

            // See if it's time to load the end scene (after the delay)
            if (Time.time >= m_TimeLoadEndGameScene)
            {
                SceneManager.LoadScene(nextSceneIndex);
                gameIsEnding = false;
            }
        }
        else
        {
            if (m_ObjectiveManager.AreAllObjectivesCompleted())
                EndGame(true);

            // Test if player died
            if (m_Player.isDead)
                EndGame(false);
        }
    }

    void EndGame(bool win)
    {
        // unlocks the cursor before leaving the scene, to be able to click buttons
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Remember that we need to load the appropriate end scene after a delay
        gameIsEnding = true;
        endGameFadeCanvasGroup.gameObject.SetActive(true);
        if (win)
        {
            // Set next scene to play next in build settings. Set to main menu if all levels finished.
            // If Replay Level is checked, level won't advance. Used for testing.
            if (!ReplayScene)
            {
                nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextSceneIndex > SceneManager.sceneCountInBuildSettings - 1)
                {
                    Debug.Log("Index " + nextSceneIndex + " is out of bounds. Returning to Main Menu.");
                    nextSceneIndex = 0;
                }
            } else {
                nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
            }

            m_TimeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;

            // play a sound on win
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = victorySound;
            audioSource.playOnAwake = false;
            audioSource.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.HUDVictory);
            audioSource.PlayScheduled(AudioSettings.dspTime + delayBeforeWinMessage);

            // create a game message
            var message = Instantiate(WinGameMessagePrefab).GetComponent<DisplayMessage>();
            if (message)
            {
                message.delayBeforeShowing = delayBeforeWinMessage;
                message.GetComponent<Transform>().SetAsLastSibling();
            }
        }
        else
        {
            // Set next scene to load to replay active scene
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex;

            m_TimeLoadEndGameScene = Time.time + endSceneLoadDelay;
        }
    }
}
