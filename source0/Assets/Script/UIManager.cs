using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PC1 PC1;
    public PC2AI pc2ai;

    public Text nLevel; // Modified to pcRotText
    public Text P1HP;
    public Text P2HP;
    public Text fDifficulty_lv;

    public Image plus_button;
    public Image minus_button;
    public Image multi_button;
    public Image chaos_button;


    public Image pc1win;
    public Image pc2win;


    public Button StartButton; // Modified to shotButton
    public Button clearButton;
    public Button gameoverButton;


    public Image clearImage; // Modified to clearImage
    public Image StartImage;


    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (pc1win != null)
        {
            pc1win.transform.position = new Vector3(999, 480);
            pc1win.gameObject.SetActive(false);
        }
        if (pc2win != null)
        {
            pc2win.transform.position = new Vector3(1024, 500);
            pc2win.gameObject.SetActive(false);
        }
        if (clearImage != null)
        {
            clearImage.transform.position = new Vector3(0, 0);
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

        P1HP.text = PC1.HP.ToString();
        P2HP.text = pc2ai.HP.ToString();

    }

    public void GameClear()
    {
        Time.timeScale = 0f;
        clearImage.gameObject.SetActive(true);

    }

    public void pc1winpopup(int i)
    {
        if (i == 1)
        {
            Time.timeScale = 0f;
            pc1win.gameObject.SetActive(true);
        }
  else      if (i == 2)
        {
            Time.timeScale = 0f;
            pc2win.gameObject.SetActive(true);
        }

    }

    public void pc2winpopup()
    {
        Time.timeScale = 0f;
        pc2win.gameObject.SetActive(true);

    }


}

