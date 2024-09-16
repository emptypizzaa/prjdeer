using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LogoScene : MonoBehaviour
{
    void Awake()
    {
      //  Application.targetFrameRate = 60;   

     //   Social.localUser.Authenticate(ProcessAuthentication);
    }
    
    static void ProcessAuthentication(bool result)
    {
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("TitleScene");
    }
}
