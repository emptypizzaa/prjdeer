using UnityEngine;

public class PC2AI : MonoBehaviour
{
    public int HP = 25; // AI 캐릭터의 초기 HP
    public int maxHP = 25; // 최대 HP
    public GameObject cake; // 케이크 오브젝트
    public float cakeMoveDistance = 1.0f; // 케이크를 움직일 거리 (픽셀)
    public float turnInterval = 2.0f; // 턴 간격 (초)

    private void Start()
    {
        // 1턴마다 행동을 결정하도록 반복 실행
        InvokeRepeating(nameof(ChooseAction), 1.0f, turnInterval);
    }

    private void ChooseAction()
    {
        if (HP <= 0)
        {
            Debug.Log("PC2AI has no HP left.");
            return;
        }

        float randomValue = Random.Range(0f, 1f);
        if (randomValue < 0.7f)
        {
            OnPlusButtonPressed();
        }
        else
        {
            OnMinusButtonPressed();
        }
    }

    // '+' 버튼을 선택했을 때 호출되는 메소드
    public void OnPlusButtonPressed()
    {
        if (HP > 0)
        {
            HP--;
            MoveCake(-cakeMoveDistance); // AI는 케이크를 왼쪽으로 이동
            Debug.Log("PC2AI chooses +. HP: " + HP);
        }
        else
        {
            Debug.Log("PC2AI has no HP left.");
        }
    }

    // '-' 버튼을 선택했을 때 호출되는 메소드
    public void OnMinusButtonPressed()
    {
        if (HP < maxHP)
        {
            HP = Mathf.Min(HP + 2, maxHP);
            MoveCake(+cakeMoveDistance); // AI는 케이크를 왼쪽으로 이동
            Debug.Log("PC2AI chooses -. HP increased to: " + HP);
        }
        else
        {
            Debug.Log("PC2AI's HP is already at maximum.");
        }
    }

    // 케이크를 이동시키는 메소드
    private void MoveCake(float distance)
    {
        Vector3 newPosition = cake.transform.position;
        newPosition.x += distance; // 케이크를 왼쪽으로 이동
        cake.transform.position = newPosition;
    }
}
