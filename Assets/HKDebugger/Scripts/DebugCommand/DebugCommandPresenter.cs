using System;
using UnityEngine.UIElements;

namespace HKDebugger.DebugCommand
{
    public class DebugCommandPresenter : Presenter
    {
        private NodeData root;

        private NodeData current;

        private DebugCommandDocument document;

        public DebugCommandPresenter(DebugCommandDocument documentPrefab)
        {
            this.root = new NodeData(".", null, null);
            this.document = HKDebuggerSystem.AddDocument(documentPrefab);
            
            this.DeployNodeData(this.root);
            
            this.document.PreviousButton.clicked += () =>
            {
                if (this.current.Parent == null)
                {
                    return;
                }
                
                this.DeployNodeData(this.current.Parent);
            };
        }

        public void AddCommand(string path, Action command)
        {
            var nodeData = this.root;
            var splitPaths = path.Split("/");
            for(var i=0; i<splitPaths.Length; i++)
            {
                var name = splitPaths[i];
                var isCommand = i == splitPaths.Length - 1;
                var child = nodeData.GetChild(name);
                if (child == null)
                {
                    child = new NodeData(name, nodeData, isCommand ? command : null);
                    nodeData.AddChild(child);
                }
                
                nodeData = child;
            }
        }

        private void DeployNodeData(NodeData nodeData)
        {
            var listItems = nodeData.Children;
            var listView = this.document.ElementListView;
            listView.makeItem = () => this.document.ElementAsset.Instantiate();
            listView.bindItem = (v, i) =>
            {
                v.Q<DebugCommandDocumentElement>().Register(this, listItems[i]);
            };
            listView.unbindItem = (v, i) =>
            {
                v.Q<DebugCommandDocumentElement>().UnRegister();
            };
            listView.itemsSource = listItems;

            this.document.Path.text = nodeData.FullPath;
            this.current = nodeData;
        }

        public void InvokeCommand(NodeData nodeData)
        {
            if (nodeData.IsCommandNode)
            {
                nodeData.Command();
            }
            else
            {
                DeployNodeData(nodeData);
            }
        }
    }
}
