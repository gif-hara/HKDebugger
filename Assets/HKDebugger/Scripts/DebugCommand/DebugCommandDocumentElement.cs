using UnityEngine.UIElements;

namespace HKDebugger.DebugCommand
{
    public class DebugCommandDocumentElement : VisualElement
    {
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
        }

        public new class UxmlFactory : UxmlFactory<DebugCommandDocumentElement, UxmlTraits>
        {
        }

        private DebugCommandPresenter presenter;
        
        private NodeData item;
        
        public void Register(DebugCommandPresenter presenter, NodeData item)
        {
            this.presenter = presenter;
            this.item = item;
            this.Q<Label>().text = item.Name;
            this.Q<Button>().clicked += this.OnClickedButton;
        }

        public void UnRegister()
        {
            this.Q<Button>().clicked -= OnClickedButton;
        }

        private void OnClickedButton()
        {
            this.presenter.InvokeCommand(this.item);
        }
    }
}
