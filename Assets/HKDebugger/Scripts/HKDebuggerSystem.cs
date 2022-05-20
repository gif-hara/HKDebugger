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

        private static readonly List<Document> documents = new ();

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

        public static TDocument AddDocument<TDocument>(TDocument documentPrefab) where TDocument : Document
        {
            var instance = Object.Instantiate(documentPrefab, rootObject.transform);
            documents.Add(instance);

            return instance;
        }

        public static void DestroyDocument(Document document)
        {
            documents.Remove(document);
            Object.Destroy(document.gameObject);
        }
    }
}
