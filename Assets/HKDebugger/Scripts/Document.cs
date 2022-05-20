using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

namespace HKDebugger
{
    /// <summary>
    /// ViewとなるUIDocumentを制御する抽象クラス
    /// </summary>
    [RequireComponent(typeof(UIDocument))]
    public abstract class Document : MonoBehaviour
    {
        private UIDocument uiDocument;

        /// <summary>
        /// <see cref="UIDocument"/>を返す
        /// </summary>
        /// <returns></returns>
        protected UIDocument GetUIDocument()
        {
            if (this.uiDocument == null)
            {
                this.uiDocument = GetComponent<UIDocument>();
                Assert.IsNotNull(this.uiDocument);
            }

            return this.uiDocument;
        }
        
        /// <summary>
        /// ルートの<see cref="VisualElement"/>を返す
        /// </summary>
        protected VisualElement GetRoot() => this.GetUIDocument().rootVisualElement;
    }
}
