using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HKDebugger
{
    public class HKDebuggerSystem
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
        }
    }
}
