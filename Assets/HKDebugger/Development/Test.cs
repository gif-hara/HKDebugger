using HKDebugger;
using HKDebugger.DebugCommand;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var debugCommandUIPresenter = HKDebuggerSystem.GetPresenter<DebugCommandPresenter>();
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
