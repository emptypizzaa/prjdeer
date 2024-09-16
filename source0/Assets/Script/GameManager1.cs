
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public Player pc1; // PC1의 Player 스크립트
    public PC2AI pc2;  // PC2의 AI 스크립트
    public Cake cake; // Cake 스크립트

    public Transform p1Circle; // PC1의 원 위치
    public Transform p2Circle; // PC2의 원 위치

    public GameObject winPopup; // 승리 팝업창 (Canvas의 UI Element)

    public Text winText; // 승리 텍스트 (UI Text)



    public UIManager UIManager;
    void Start()
    {
       // winPopup.SetActive(false); // 시작 시 승리 팝업 비활성화
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
            GameClear(1);
        }
        else if (distanceToP2 < 0.5f) // PC2 원 안에 도달
        {
            GameClear(2);
        }
    }

    void GameClear(int n)
    {
        Time.timeScale = 0f; // 게임 일시 정지
       // 승리 팝업창 활성화

        
            UIManager.pc1winpopup(n);
            winText.text = "Player "+n.ToString() +" Wins!";
            Debug.Log("Player" +n.ToString() +  " is the winner!");
   
    }
}