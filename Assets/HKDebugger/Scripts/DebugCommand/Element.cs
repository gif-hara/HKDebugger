using HKDebugger.DebugCommand;
using UnityEngine.UIElements;

namespace HKDebugger.UIElements
{
    public class Element : VisualElement
    {
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
        }

        public new class UxmlFactory : UxmlFactory<Element, UxmlTraits>
        {
        }

        private DebugCommandUIPresenter presenter;
        
        private NodeData item;
        
        public void Register(DebugCommandUIPresenter presenter, NodeData item)
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
