using System.Collections;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 0.5f;                              // 1ĭ �̵��� �ҿ�Ǵ� �ð�

    public Vector3 MoveDirection { set; get; } = Vector3.zero;  // �̵� ����
    public bool IsMove { set; get; } = false;           // ���� �̵�������

    private IEnumerator Start()
    {
        while (true)
        {
            if (MoveDirection != Vector3.zero && IsMove == false)
            {
                Vector3 end = transform.position + MoveDirection;

                yield return StartCoroutine(GridSmoothMovement(end));
            }

            yield return null;
        }
    }

    private IEnumerator GridSmoothMovement(Vector3 end)
    {
        Vector3 start = transform.position;
        float current = 0;
        float percent = 0;

        IsMove = true;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }

        IsMove = false;
    }
}

