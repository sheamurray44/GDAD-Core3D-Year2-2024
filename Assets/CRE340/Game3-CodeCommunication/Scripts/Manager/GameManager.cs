using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton Implementation

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null )
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }

    #endregion

    #region Properties and Fields

    public GameObject playerPrefab;
    private Player playerInstance;

    [SerializeField] private string playerName = "Player1";
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int score = 0;

    #endregion

    #region Unity Methods
    private void Start()
    {
        Debug.Log("GameManager initialized with default player state.");
    }
    #endregion

    #region Custom Public Methods

    public void SpawnPlayer(Vector3 spawnPosition)
    {
        if (playerInstance == null)
        {
            GameObject playerObject = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
            playerInstance = playerObject.GetComponent<Player>();
        }
    }

    #endregion
}