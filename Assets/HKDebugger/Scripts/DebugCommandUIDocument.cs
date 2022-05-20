using UnityEngine;
using UnityEngine.UIElements;

namespace HKDebugger
{
    /// <summary>
    /// DebugCommandのView
    /// </summary>
    [RequireComponent(typeof(UIDocument))]
    public class DebugCommandUIDocument : Document
    {
        [SerializeField]
        private VisualTreeAsset elementAsset;
        
        /// <summary>
        /// リストの要素のアセット
        /// </summary>
        public VisualTreeAsset ElementAsset => this.elementAsset;
        
        /// <summary>
        /// 戻るボタン
        /// </summary>
        public Button PreviousButton => this.GetRoot().Q<Button>("PreviousButton");

        /// <summary>
        /// パス
        /// </summary>
        public Label Path => this.GetRoot().Q<Label>("Path");

        /// <summary>
        /// メニューボタン
        /// </summary>
        public Button MenuButton => this.GetRoot().Q<Button>("MenuButton");

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        public Button CloseButton => this.GetRoot().Q<Button>("CloseButton");

        /// <summary>
        /// 要素のリスト
        /// </summary>
        public ListView ElementListView => this.GetRoot().Q<ListView>("ElementListView");
    }
}
