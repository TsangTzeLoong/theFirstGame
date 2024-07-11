using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dialogueText;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private GameObject dialogueCanvas;

    private string[] dialogues;
    private int currentDialogueIndex;

    void Start()
    {
        ///dialogueCanvas.gameObject.SetActive(true);
        // 初始化对话数组
        dialogues = new string[]
        {
            "HELLO!!",
            "LET'S GOOOO!",
            "TEST",
            "OVER"
        };

        currentDialogueIndex = 0;
        ShowDialogue();

        nextButton.onClick.AddListener(NextDialogue);
    }

    private void ShowDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
    }

    private void NextDialogue()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            ShowDialogue();
        }
        else
        {
            // 所有对话完成，进行下一步操作（例如开始游戏）
            dialogueText.text = "END!";
            nextButton.onClick.RemoveAllListeners();
            nextButton.gameObject.SetActive(false);
            dialogueCanvas.gameObject.SetActive(false);
        }
    }
}
