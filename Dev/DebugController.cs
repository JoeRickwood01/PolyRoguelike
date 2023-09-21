using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour {
    bool showConsole;
    string input;

    [SerializeField] private InputField inputField;
    [SerializeField] private RectTransform debugConsolePanel;

    //public static DebugCommand<int> Spawn;
    public static DebugCommand<int> GiveItem;
    public static DebugCommand<int> SetRound;

    public List<object> commandList;

    void Update() {
        if(Input.GetKeyDown(KeyCode.BackQuote)) {
            OnToggleDebug();
        }    

        if(!showConsole) { return; }
        if(Input.GetKeyDown(KeyCode.Return)) {
            HandleInput();
            input = "";
        }
    }

    public void OnToggleDebug() {
        showConsole = !showConsole;

        if(showConsole == true) {
            debugConsolePanel.gameObject.SetActive(true);
            inputField.Select();
            inputField.ActivateInputField();
        }else {
            debugConsolePanel.gameObject.SetActive(false);
            inputField.text = "";
        }
    }

    void Awake() {
        GiveItem = new DebugCommand<int>("give", "Adds Item To Player Inventory", "give <ItemID>", (x) =>
        {
            InventoryManager.Instance.AddItemToInventory(InventoryManager.Instance.GetItemWithID((int)Mathf.Clamp(x, 0, InventoryManager.Instance.itemDatabase.Length - 1)));
        });

        SetRound = new DebugCommand<int>("setround", "Sets The Games Current Round", "setround <Round>", (x) =>
        {
            Level.Instance.round = (int)Mathf.Clamp(x, 0, Mathf.Infinity);
        });

        commandList = new List<object> {
            GiveItem,
            SetRound
        };
    }

    private void HandleInput() {
        input = inputField.text.ToLower();

        if(input == "") { return; }

        string[] properties = input.Split(" ");

        for (int i = 0; i < commandList.Count; i++) {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if(input.Contains(commandBase.commandId)) {
                if(commandList[i] as DebugCommand != null) {
                    (commandList[i] as DebugCommand).Invoke();
                }else if(commandList[i] as DebugCommand<int> != null && properties.Length > 1) {
                    (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                }else if(commandList[i] as DebugCommand<float> != null && properties.Length > 1) {
                    (commandList[i] as DebugCommand<float>).Invoke(float.Parse(properties[1]));
                }
            }
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }
}
