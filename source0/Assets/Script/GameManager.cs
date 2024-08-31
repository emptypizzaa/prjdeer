using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{


    public Player pc1; // PC1의 Player 스크립트
    public Cake cake; // Cake 스크립트
    public PC2AI pc2;  // PC2의 AI 스크립트
    public Transform p1Circle; // PC1의 원 위치
    public Transform p2Circle; // PC2의 원 위치
    public float moveDuration = 1.5f; // 케이크 이동 시간

 
    public float checkInterval = 1.2f; // 승리 조건 체크 간격

    private float timeSinceLastCheck = 0f;



    private Vector3 originalPosition;//ㅁㅜㅓㅇㅔㅇㅗㅐㅁㄴㅇㅈㅐ
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {

        // 게임 초기화 시 필요한 작업 수행
        // Initialize the cake's original position
        // originalPosition = cake.transform.position;
    }

    void Update()
    {
        // The Update method should handle input and game logic rather than moving the cake
        // Removed the dtime-based movement logic here

        // Example: Handle player and AI inputs
        // Assuming a method that gets called when a player or AI decides to move the cake
        // 시간 경과를 추적
        timeSinceLastCheck += Time.deltaTime;

        // 1.2초가 경과하면 승리 조건 체크
        if (timeSinceLastCheck >= checkInterval)
        {
            CheckVictoryCondition();
            timeSinceLastCheck = 0f; // 경과 시간 리셋
        }
    }
    void CheckVictoryCondition()
    {
        float distanceToP1 = Vector3.Distance(cake.transform.position, p1Circle.position);
        float distanceToP2 = Vector3.Distance(cake.transform.position, p2Circle.position);

        if (distanceToP1 < 0.5f) // PC1 원 안에 도달
        {
            Debug.Log("PC1 Wins!");
            GameClear(pc1);
        }
        else if (distanceToP2 < 0.5f) // PC2 원 안에 도달
        {
            Debug.Log("PC2 Wins!");
           // GameClear(pc2);
        }
    }

    void GameClear(Player winner)
    {
        Time.timeScale = 0f;
        // 승리 조건에 따라 게임 결과 화면 출력 등 추가 작업 수행
        Debug.Log(winner.name + " is the winner!");
        // 승자에 따른 추가 로직
    }
}
/*
 * 
 * using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player pc1; // PC1의 Player 스크립트
    public Player pc2;  // PC2의 AI 스크립트
    public Cake cake; // Cake 스크립트

    public Transform p1Circle; // PC1의 원 위치
    public Transform p2Circle; // PC2의 원 위치

    public GameObject winPopup; // 승리 팝업창 (Canvas의 UI Element)

    public Text winText; // 승리 텍스트 (UI Text)

    void Start()
    {
        winPopup.SetActive(false); // 시작 시 승리 팝업 비활성화
    }

    void Update()
    {
        // Trigger로 대체 가능
        CheckVictoryCondition();
    }

    void CheckVictoryCondition()
    {
        float distanceToP1 = Vector3.Distance(cake.transform.position, p1Circle.position);
        float distanceToP2 = Vector3.Distance(cake.transform.position, p2Circle.position);

        if (distanceToP1 < 0.5f) // PC1 원 안에 도달
        {
            GameClear(pc1);
        }
        else if (distanceToP2 < 0.5f) // PC2 원 안에 도달
        {
            GameClear(pc2);
        }
    }

    void GameClear(Player winner)
    {
        Time.timeScale = 0f; // 게임 일시 정지
        winPopup.SetActive(true); // 승리 팝업창 활성화

        if (winner == pc1)
        {
            winText.text = "Player 1 Wins!";
        }
        else if (winner == pc2)
        {
            winText.text = "Player 2 Wins!";
        }
    }
}
*/


/*using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player pc1; // PC1의 Player 스크립트
    public Cake cake; // Cake 스크립트
    public PC2AI pc2;  // PC2의 AI 스크립트
    public Transform p1Circle; // PC1의 원 위치
    public Transform p2Circle; // PC2의 원 위치
    public float moveDuration = 1.5f; // 케이크 이동 시간
    public float checkInterval = 1.2f; // 승리 조건 체크 간격

    private float timeSinceLastCheck = 0f;

    void Start()
    {
        // 필요한 초기화 작업
    }

    void Update()
    {
        // 시간 경과를 추적
        timeSinceLastCheck += Time.deltaTime;

        // 1.2초가 경과하면 승리 조건 체크
        if (timeSinceLastCheck >= checkInterval)
        {
            CheckVictoryCondition();
            timeSinceLastCheck = 0f; // 경과 시간 리셋
        }
    }

    void CheckVictoryCondition()
    {
        float distanceToP1 = Vector3.Distance(cake.transform.position, p1Circle.position);
        float distanceToP2 = Vector3.Distance(cake.transform.position, p2Circle.position);

        if (distanceToP1 < 0.5f) // PC1 원 안에 도달
        {
            Debug.Log("PC1 Wins!");
            GameClear(pc1);
        }
        else if (distanceToP2 < 0.5f) // PC2 원 안에 도달
        {
            Debug.Log("PC2 Wins!");
            GameClear(pc2);
        }
    }

    void GameClear(Player winner)
    {
        Time.timeScale = 0f;
        // 승리 조건에 따라 게임 결과 화면 출력 등 추가 작업 수행
        Debug.Log(winner.name + " is the winner!");
        // 승자에 따른 추가 로직
    }
}
*/
