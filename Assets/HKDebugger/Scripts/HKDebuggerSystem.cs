using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

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

        private static readonly List<Presenter> presenters = new();

        private static readonly List<Document> documents = new ();

        public static void Initialize()
        {
            if (rootObject != null)
            {
                return;
            }

            rootObject = new GameObject("HKDebugger");
            Object.DontDestroyOnLoad(rootObject);

            var settings = GlobalSettings.Instance;
            foreach (var initializer in settings.Initializers)
            {
                AddPresenter(initializer);
            }
        }

        public static void Finalize()
        {
            if (rootObject == null)
            {
                return;
            }
            
            Object.Destroy(rootObject);
        }
        
        public static Presenter AddPresenter(Initializer initializer)
        {
            return AddPresenter(initializer.CreatePresenter());
        }

        public static Presenter AddPresenter(Presenter presenter)
        {
            presenters.Add(presenter);

            return presenter;
        }

        public static TPresenter GetPresenter<TPresenter>() where TPresenter : Presenter
        {
            foreach (var presenter in presenters)
            {
                if (presenter.GetType() == typeof(TPresenter))
                {
                    return presenter as TPresenter;
                }
            }
            
            Assert.IsTrue(false, $"{typeof(TPresenter)} did not exist.");
            return null;
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
