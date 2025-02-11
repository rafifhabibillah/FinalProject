using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogNpcController : MonoBehaviour
{
    public GameObject dialogContainer;
    public GameObject HUD;
    public Text dialogText;
    private bool isOnDialog = false;
    [SerializeField] GameObject closeDialogButton;

    private void Start() {
        closeDialogButton.GetComponent<Button>().onClick.AddListener(EndDialog);
    }
    public void EndDialog(){
        dialogContainer.SetActive(false);
        HUD.SetActive(true);
        isOnDialog = false;
        Camera.main.GetComponent<FollowPlayer>().SetIsZoom(false);
    }
    public void StartDialog(string text){
        HUD.SetActive(false);
        dialogText.text = text;
        dialogContainer.SetActive(true);
        isOnDialog = true;
        Camera.main.GetComponent<FollowPlayer>().SetIsZoom(true);
    }
    public void Update(){
        if((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Interact")) && isOnDialog) EndDialog();
    }
}
