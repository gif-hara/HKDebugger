using System;
using System.Collections.Generic;
using System.Text;

namespace HKDebugger.DebugCommand
{
    public class NodeData
    {
        public string Name { get; }
        
        public NodeData Parent { get; }

        public readonly List<NodeData> Children = new();

        public Action Command { get; }
        
        public string FullPath { get; }

        public NodeData(string name, NodeData parent, Action command)
        {
            this.Name = name;
            this.Parent = parent;
            this.Command = command;
            if (this.Parent == null)
            {
                this.FullPath = this.Name;
            }
            else
            {
                this.FullPath = this.Parent.FullPath + "/" + this.Name;
            }
        }

        public void AddChild(NodeData child)
        {
            this.Children.Add(child);
        }

        public void RemoveChild(string name)
        {
            this.Children.RemoveAt(this.Children.FindIndex(x => x.Name == name));
        }

        public bool ContainsChildren(string name)
        {
            return this.Children.FindIndex(x => x.Name == name) >= 0;
        }

        public NodeData GetChild(string name)
        {
            return this.Children.Find(x => x.Name == name);
        }
        
        public bool IsCommandNode => this.Command != null;
    }
}
