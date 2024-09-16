using System.Collections;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isActive = false; // 셀이 현재 켜져 있는지 나타내는 플래그.
    public float activeDuration = 2.2f; // 셀이 꺼지기 전까지의 지속 시간.

    private float timer = 0f; // 활성 상태 지속 시간을 추적하기 위한 타이머.
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                DeactivateCell();
            }
        }
    }

    public void ActivateCell()
    {
        isActive = true;
        spriteRenderer.color = Color.yellow;
        timer = activeDuration; // 셀이 활성화될 때마다 타이머를 리셋합니다.
    }

    public void DeactivateCell()
    {
        isActive = false;
        spriteRenderer.color = Color.white; // 원래의 색상이 흰색이라고 가정하고, 필요한 경우 변경합니다.
    }
}
