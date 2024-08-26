using UnityEngine;
using UnityEngine.UI;

public class PersistentText : MonoBehaviour{
    private static PersistentText instance;

    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject); // 保留此对象
        }
        else{
            Destroy(gameObject); // 如果已经存在一个实例，销毁新的实例
        }
    }

    void OnEnable(){
        // 当场景加载完毕时，将Text组件挂载到新场景的Canvas上
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable(){
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode){
        // 查找新场景中的Canvas
        Canvas newCanvas = FindObjectOfType<Canvas>();
        if (newCanvas != null){
            // 将Text组件重新设置为Canvas的子对象
            transform.SetParent(newCanvas.transform, false);
        }
    }
}
