using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public PC2AI pc2ai;

    public Text nLevel; // Modified to pcRotText
    public Text P1HP;
    public Text P2HP;
    public Text fDifficulty_lv;

    public Image plus_button;
    public Image minus_button;
    
    public Image multi_button;
    public Image chaos_button;




    public Button StartButton; // Modified to shotButton
    public Button clearButton;
    public Button gameoverButton;


    public Image clearImage; // Modified to clearImage
    public Image StartImage;


    void Start()
    {
       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (clearImage != null)
        {
            clearImage.transform.position = new Vector3(580, 1180);
            clearImage.gameObject.SetActive(false);
        }

       
    }
    public void GameStart()
    {
        Time.timeScale = 1f;
        StartImage.gameObject.SetActive(false);

    }


    void Update()
    {

        P1HP.text = player.HP.ToString();
        P2HP.text = pc2ai.HP.ToString();

    }

    public void GameClear()
    {
        Time.timeScale = 0f;
        clearImage.gameObject.SetActive(true);

    }

}

