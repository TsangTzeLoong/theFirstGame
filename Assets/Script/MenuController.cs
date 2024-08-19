using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour{

[SerializeField]
private Button _startBtn;
[SerializeField]
private Button _exitBtn;
[SerializeField]
private GameObject _exitGameConfirmUI;
[SerializeField]
private Button _yesBtn;
[SerializeField]
private Button _noBtn;
    void Start(){
        _startBtn.onClick.AddListener(StartGame);
        _exitBtn.onClick.AddListener(CloseGamePop);
        _yesBtn.onClick.AddListener(ExitGame);
        _noBtn.onClick.AddListener(CloseGameCancel);
    }

    private void StartGame(){
        //SceneManager.LoadSceneAsync(1);
        SceneManager.LoadScene("MainScene");
        Debug.Log("game started");
    }
    private void CloseGamePop(){
        _exitGameConfirmUI.SetActive(true);
    }
    private void CloseGameCancel(){
        _exitGameConfirmUI.SetActive(false);
    }
    public void ExitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // 在编辑器模式下停止播放
        #else
            Application.Quit(); // 在发布模式下退出应用程序
        #endif
    }
}
