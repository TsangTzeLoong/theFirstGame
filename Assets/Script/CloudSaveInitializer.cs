using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;

public class CloudSaveInitializer : MonoBehaviour{
    async void Start(){
        await InitializeUnityServices();
    }

    // 用于初始化 Unity Services 的方法
    private async Task InitializeUnityServices(){
        try{
            // 初始化 Unity Services
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services initialized successfully!");

            // 用户匿名登录
            if (!AuthenticationService.Instance.IsSignedIn){
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("User signed in anonymously!");
            }
        }
        catch (System.Exception e){
            Debug.LogError($"Failed to initialize Unity Services: {e.Message}");
        }
    }
}
