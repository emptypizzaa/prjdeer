using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Ready,
    Play,
    Pause,
    Clear,
    Gameover,
    FinalResult,
    AskEnd,
    DieDeley
}

public class GameManager : MonoBehaviour
{
    [Header("Grid System")]
    [SerializeField] private GameObject gridCellPrefab; // 그리드 셀의 프리팹
    private GameObject[,] gridObjects; // 6x8 그리드 객체 배열
    public int gridWidth = 9;
    public int gridHeight = 9;

    // Singleton implementation
    public static GameManager Instance;

    // UI Manager
    public UIcode UIManager;

    // Gameplay variables
    public GameState GS;
    public int nGameScore_current;
    public int nGameScore_Best;
    public float fGametime;
    public static int nLevel;
    public float LeftLimit = -8.9f;
    public float RightLimit = 9;
    public float TopLimit = 30f;
    public float BottomLimit = -9f;

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void InitializeGame()
    {
        Debug.LogFormat("Loading a new level {0}...", nLevel);
        GS = GameState.Ready;
        nGameScore_current = 0;
        nGameScore_Best = 0;
        fGametime = 0f;
        Time.timeScale = 1f;

        LeftLimit = -8.9f;
        RightLimit = 9;
        TopLimit = 30f;
        BottomLimit = -9f;
        if (GameManager.nLevel >= 1)
            SoundManager.Instance.PlayBackgroundMusic(nLevel);
    }

    private void Start()
    {
        UIManager = FindObjectOfType<UIcode>();
        if (UIManager == null)
            Debug.LogError("UIManager not found.");

        InitializeGame();
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        gridObjects = new GameObject[gridWidth, gridHeight];

        float startingX = (-gridWidth / 2.0f) + 0.5f;
        float startingY = (-gridHeight / 2.0f) + 0.5f;
        float borderThickness = 0.05f; // 테두리 두께 설정

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject cell = Instantiate(gridCellPrefab, new Vector3(startingX + x, startingY + y, 0), Quaternion.identity, transform);
                gridObjects[x, y] = cell;

                // 테두리 생성
                CreateBorder(cell.transform, borderThickness);
            }
        }
    }

    private void CreateBorder(Transform parent, float thickness)
    {
        GameObject top = new GameObject("Top Border");
        GameObject bottom = new GameObject("Bottom Border");
        GameObject left = new GameObject("Left Border");
        GameObject right = new GameObject("Right Border");

        GameObject[] borders = { top, bottom, left, right };

        foreach (GameObject border in borders)
        {
            border.transform.SetParent(parent);
            border.AddComponent<SpriteRenderer>().color = Color.blue;
        }

        top.transform.localScale = new Vector3(1, thickness, 1);
        bottom.transform.localScale = new Vector3(1, thickness, 1);
        left.transform.localScale = new Vector3(thickness, 1, 1);
        right.transform.localScale = new Vector3(thickness, 1, 1);

        top.transform.localPosition = new Vector3(0, 0.5f - thickness / 2, 0);
        bottom.transform.localPosition = new Vector3(0, -0.5f + thickness / 2, 0);
        left.transform.localPosition = new Vector3(-0.5f + thickness / 2, 0, 0);
        right.transform.localPosition = new Vector3(0.5f - thickness / 2, 0, 0);
    }

    public Vector2 GetGridBoundary()
    {
        float halfWidth = gridWidth / 2.0f;
        float halfHeight = gridHeight / 2.0f;

        return new Vector2(halfWidth, halfHeight);
    }

    public void ClearGame()
    {
        nLevel += 1;

        if (nLevel < 6)
            SceneManager.LoadScene(nLevel);
        else
            SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SoundManager.Instance.GameOver();
        SceneManager.LoadScene(0);   //GS = GameState.Gameover;
    }

    public void AddScore(int scoreToAdd)
    {
        nGameScore_current += scoreToAdd;
    }

    public void AddScore()
    {
        nGameScore_current += 1;
    }

    // ... [Other methods remain the same as your original script]
}



