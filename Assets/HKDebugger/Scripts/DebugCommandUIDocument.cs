using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

namespace HKDebugger
{
    [RequireComponent(typeof(UIDocument))]
    public class DebugCommandUIDocument : MonoBehaviour
    {
        [SerializeField]
        private VisualTreeAsset elementAsset;
        
        private UIDocument document;

        private UIDocument GetDocument()
        {
            if (this.document == null)
            {
                this.document = GetComponent<UIDocument>();
                Assert.IsNotNull(this.document);
            }

            return this.document;
        }

        private VisualElement GetRoot() => this.GetDocument().rootVisualElement;

        public VisualTreeAsset ElementAsset => this.elementAsset;
        
        public Button PreviousButton => this.GetRoot().Q<Button>("PreviousButton");

        public Label Path => this.GetRoot().Q<Label>("Path");

        public Button MenuButton => this.GetRoot().Q<Button>("MenuButton");

        public Button CloseButton => this.GetRoot().Q<Button>("CloseButton");

        public ListView ElementListView => this.GetRoot().Q<ListView>("ElementListView");
    }
}
