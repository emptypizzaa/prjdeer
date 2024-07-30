using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public player pc1; // Assign in inspector
    public cake cake; // Assign in inspector
    public pc2AI pc2;  // Assign in inspector
    public Vector3 originalPosition;
    public Vector3 targetPosition;
    public float dtime;

    void Start()
    {
        originalPosition = cake.transform.position;
        targetPosition = pc2.transform.position;
       
       // StartCoroutine(MoveCake());
    }



    void Upadte()
    {

        cake.transform.position = Vector3.Lerp(originalPosition, targetPosition, (dtime / 1.5f));
        dtime += Time.deltaTime;
    }

    private IEnumerator MoveCake()
    {
        while (true)
        {
            // Move cake towards pc2 over 1.5 seconds
            float elapsedTime = 0;
            originalPosition = cake.transform.position;
             targetPosition = pc2.transform.position;

            while (elapsedTime < 1.5f)
            {
                cake.transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / 1.5f));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            cake.transform.position = targetPosition; // Ensure it ends exactly at the target
            yield return new WaitForSeconds(1.5f); // Wait for 1.5 seconds before moving again   //pc1 .cs ����
                                                   //pc2(ai).cs
                                                   //ui ����� ���� ������ �ǽð�
                                                   //gamelogic states
        }
    }
}
