using System.Collections;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
	[SerializeField]
	private	float	moveTime = 0.5f;								// 1칸 이동에 소요되는 시간
	
	public	Vector3	MoveDirection	{ set; get; } = Vector3.zero;	// 이동 방향
	public	bool	IsMove			{ set; get; } = false;			// 현재 이동중인지

	private IEnumerator Start()
	{
		while ( true )
		{
			if ( MoveDirection != Vector3.zero && IsMove == false )
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
		float	current = 0;
		float	percent = 0;

		IsMove = true;

		while ( percent < 1 )
		{
			current += Time.deltaTime;
			percent = current / moveTime;

			transform.position = Vector3.Lerp(start, end, percent);

			yield return null;
		}

		IsMove = false;
	}
}

