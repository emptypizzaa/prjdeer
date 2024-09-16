using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcode : MonoBehaviour
{
    public Player player; // Modified to BallRumble // public ItemSpawner itemspawner;


    public Text nLevel; // Modified to pcRotText
    public Text gameCurrentScore;
    public Text gameBestScore;
    public Text fDifficulty_lv;

    public Image up_button;
    public Image down_button;
    public Image right_button;
    public Image left_button;
    public Image pause_button;




    public Button StartButton; // Modified to shotButton
    public Button clearButton;
    public Button gameoverButton;
    public Image clearImage; // Modified to clearImage
    public Image StartImage;


    void Start()
    {
        StartImage.transform.position = new Vector3(560, 1250);        //    StartImage.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (null == StartButton)
            StartButton = transform.Find("StartButton").gameObject.GetComponent<Button>();
        // clearButton = transform.Find("clearimg").gameObject.GetComponentInChildren<Button>();
        // gameoverButton = transform.Find("gameoverimg").gameObject.GetComponentInChildren<Button>();
        //  clearButton.onClick.AddListener(GameManager.Instance.ClearGame);// StartButton.onClick.AddListener(ballrumble_PC.OnShot);


        if (clearImage != null)
        {
            clearImage.transform.position = new Vector3(580, 1180);
            clearImage.gameObject.SetActive(false);
        }

        up_button.GetComponent<Button>().onClick.AddListener(player.MoveUp);
        down_button.GetComponent<Button>().onClick.AddListener(player.MoveDown);
        left_button.GetComponent<Button>().onClick.AddListener(player.MoveLeft);
        right_button.GetComponent<Button>().onClick.AddListener(player.MoveRight);
    }
    public void GameStart()
    {
        Time.timeScale = 1f;
        StartImage.gameObject.SetActive(false);

    }


    void Update()
    {
        /*
       nLevel.text = GameManager.nLevel.ToString();
       fDifficulty_lv.text = enemyspawner.fLeveling.ToString("F2");//추가 코드

       gameCurrentScore.text = GameManager.Instance.nGameScore_current.ToString(); // Used a method to get current score
       gameBestScore.text = GameManager.Instance.nGameScore_Best.ToString();


       if(player.bJumpOK)    // if (ballrumble_PC.IsJumpOK()) 

           shotButton.gameObject.GetComponent<Image>().color = Color.cyan;

       else

           shotButton.gameObject.GetComponent<Image>().color = Color.red;*/

    }

    public void GameClear()
    {
        Time.timeScale = 0f;
        clearImage.gameObject.SetActive(true);

    }

}

