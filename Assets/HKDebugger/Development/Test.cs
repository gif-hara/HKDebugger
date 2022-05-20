using System.Collections;
using System.Collections.Generic;
using HKDebugger;
using HKDebugger.DebugCommand;
using HKDebugger.UIElements;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    [SerializeField]
    private DebugCommandUIDocument document;

    [SerializeField]
    private VisualTreeAsset elementAsset;
    
    // Start is called before the first frame update
    void Start()
    {
        
        // this.uiDocument.rootVisualElement.Q<Button>()
        //     .clicked += () =>
        // {
        //     Debug.Log("clicked!");
        // };
        //
        // var listItems = new List<string>();
        // for (var i = 0; i < 1000; i++)
        // {
        //     listItems.Add($"Item{i}");
        // }
        //
        // var listView = this.uiDocument.rootVisualElement.Q<ListView>();
        // listView.makeItem = () =>
        // {
        //     var result = this.elementAsset.Instantiate(); 
        //     return result;
        // };
        // listView.bindItem = (v, i) =>
        // {
        //     v.Q<Element>().Register(listItems[i]);
        // };
        // listView.unbindItem = (v, i) =>
        // {
        //     v.Q<Element>().UnRegister();
        // };
        // listView.itemsSource = listItems;

        var debugCommandUIPresenter = new DebugCommandUIPresenter(this.document);
        debugCommandUIPresenter.AddCommand("HKDebuggerSystem/Initialize", () => HKDebuggerSystem.Initialize());
        debugCommandUIPresenter.AddCommand("HKDebuggerSystem/Finalize", () => HKDebuggerSystem.Finalize());
        debugCommandUIPresenter.AddCommand("Test0/Hoge/Command", () => Debug.Log("Command"));
        debugCommandUIPresenter.AddCommand("Test1/Hoge/Command", () => Debug.Log("Command"));
        debugCommandUIPresenter.AddCommand("Test2/Hoge/Command", () => Debug.Log("Command"));
        debugCommandUIPresenter.AddCommand("Test3/Hoge/Command", () => Debug.Log("Command"));
        debugCommandUIPresenter.AddCommand("Test4/Hoge/Command", () => Debug.Log("Command"));
        debugCommandUIPresenter.AddCommand("Test5/Hoge/Command", () => Debug.Log("Command"));
        debugCommandUIPresenter.AddCommand("Test6/Hoge/Command", () => Debug.Log("Command"));
    }
}
