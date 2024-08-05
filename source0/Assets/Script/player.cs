using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    public int HP = 25; // 플레이어의 초기 HP
    public int maxHP = 25; // 최대 HP
    public GameObject cake; // 케이크 오브젝트
    public float cakeMoveDistance = 1.0f; // 케이크를 움직일 거리 (픽셀)

    // '+' 버튼 클릭 시 호출되는 메소드
    public void OnPlusButtonPressed()
    {
        if (HP > 0)
        {
            HP--;
            MoveCake(cakeMoveDistance);
            Debug.Log("Player chooses +. HP: " + HP);
        }
        else
        {
            Debug.Log("Player has no HP left.");
        }
    }
    // '-' 버튼을 선택했을 때 호출되는 메소드
    public void OnMinusButtonPressed()
    {
        if (HP < maxHP)
        {
            HP = Mathf.Min(HP + 2, maxHP);
            MoveCake(-cakeMoveDistance); 
            Debug.Log("Player chooses -. HP increased to: " + HP);
        }
        else
        {
            Debug.Log("Player's HP is already at maximum.");
        }
    }

    // 케이크를 이동시키는 메소드
    private void MoveCake(float distance)
    {
        Vector3 newPosition = cake.transform.position;
        newPosition.x += distance; // 케이크를 오른쪽으로 이동
        cake.transform.position = newPosition;
    }
}
/*
{
    public GameObject cake; // Assign the cake GameObject in the inspector
    public int HP = 25;
    int atkpower = 1; // 공격력



    
    // 플레이어가 공격을 받을 때 호출되는 메소드
    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("Player takes damage: " + damage + ", HP remaining: " + HP);
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died.");
        // 사망 처리 로직 추가 (예: 게임 오버 화면, 재시작 옵션 등)
    }
    // Method to call when an interaction button is pressed
    public void TakeCake()
    {
        // Check if the cake is assigned
        if (cake != null)
        {
            // Move the cake towards the player
            StartCoroutine(MoveCakeToPlayer());
        }
        else
        {
            Debug.LogError("Cake GameObject is not assigned.");
        }
    }

    private IEnumerator MoveCakeToPlayer()
    {
        float elapsedTime = 0f;
        float duration = 1.5f; // Time in seconds it takes for the cake to move
        Vector3 originalPosition = cake.transform.position;
        Vector3 targetPosition = transform.position + new Vector3(0, 0, -1); // Slight offset to place the cake in front of the player

        while (elapsedTime < duration)
        {
            cake.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cake.transform.position = targetPosition; // Ensure the cake is exactly at the target position
    }


}


*/