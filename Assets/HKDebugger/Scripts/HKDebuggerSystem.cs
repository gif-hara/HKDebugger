using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HKDebugger
{
    public class HKDebuggerSystem
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeOnBeforeSceneLoad()
        {
            Initialize();
        }

        private static GameObject rootObject;

        public static void Initialize()
        {
            if (rootObject != null)
            {
                return;
            }

            rootObject = new GameObject("HKDebugger");
            Object.DontDestroyOnLoad(rootObject);
        }

        public static void Finalize()
        {
            if (rootObject == null)
            {
                return;
            }
            
            Object.Destroy(rootObject);
        }
    }
}
