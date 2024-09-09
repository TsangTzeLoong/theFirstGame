using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dialogueTxt;
    [SerializeField]
    private Button nextDialogueBtn;
    [SerializeField]
    private GameObject dialogueCanvas;
    private LocalizationManager localizationManager;
    void Start(){
        localizationManager = new LocalizationManager();
        localizationManager.LoadLocalizedText("en_localization.json");

        ShowDialogue();

        dialogueTxt.text = localizationManager.GetLocalizedValue("greeting");
        Debug.Log(dialogueTxt.text);
        nextDialogueBtn.onClick.AddListener(NextDialogue);
    }

    private void ShowDialogue(){
        
    }
    private void NextDialogue(){
        dialogueTxt.text = localizationManager.GetLocalizedValue("thanks");
    }
    void EndDialogue(){
        // 一段对话结束了 关掉对话框
        dialogueCanvas.gameObject.SetActive(false);
    }
    private void OnDestroy() {
        nextDialogueBtn.onClick.RemoveAllListeners();
    }
}
