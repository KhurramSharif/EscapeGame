using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    static GamePlayController _instance;
    public GameObject LosePanel;
    public GameObject InfoPanel;
    public GameObject WinPanel;
    public Text PlayTime;
    public Text BestPlayTime;
    
    
    
    public GameObject Player;
    private float _timeplay = 0.0f;

    private void Start()
    { 
        _instance = this;
        Time.timeScale = 1.0f;
        Globals.TotalKeyPickedUp = 0;
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        OnShowInfopanel();
        
    }

    public static GamePlayController Instance()
    {
        return _instance;
    }

    public void OnDead()
    {
        Debug.Log("Player Hit");
        StartCoroutine(DestroyPlayer());
        
    }

    private void Update()
    {
        _timeplay += Time.deltaTime;
    }


    IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(0.2f);

        foreach (Transform child in Player.transform)
        {
            Destroy(child.gameObject);
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(Player);
        LosePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    
    public void OnExitReached()
    {
        if (Globals.TotalKeyPickedUp > 2)
        {
            OnWin();
        }
        else
        {
            OnShowInfopanel();
        }

    }

    public void OnWin()
    {
        WinPanel.SetActive(true);
        PlayTime.text =((int) _timeplay).ToString();
        Utils.Instance().UpdateBestTime(_timeplay);
        BestPlayTime.text = ((int) Utils.GetFloat(Constants.BestTime)).ToString();

    }
    
    public void OnHideInfopanel()
    {
        InfoPanel.SetActive(false);
        
    }
    
    public void OnShowInfopanel()
    {
        InfoPanel.SetActive(true);
        Invoke("OnHideInfopanel", 2.0f);
    }
    
    public void OnRetry()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    
    public void OnExit()
    {
        Application.Quit();
    }
}
