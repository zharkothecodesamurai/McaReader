using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodeCreate;

namespace TreeBuilder
{
    public class Tree
    {
        Node root;
        Dictionary<int, Node> treeNodes;

        public Tree(List<Node> nodes)
        {
            root = new Node();
            buildTree(nodes);
        }

        private void buildTree(List<Node> nodes)
        {
            treeNodes = new Dictionary<int, Node>(nodes.Count);
            foreach(Node item in nodes)
            {
                treeNodes.Add(item.ID, item);
            }

            foreach (Node item in nodes)
            {
               
                Node parentNode = treeNodes.GetValueOrDefault(item.ParentID);
                if (parentNode != null)
                    parentNode.addChild(item);
                else
                    root.addChild(item);
            }
           
       
            SortAllChildren();
        }
        public void printTreeCascade(Node node, String dots)
        {
            if (!node.IsHidden)
                Console.WriteLine(dots + " " + node);

            foreach (Node child in node.children)
            {
                if (node == root)
                {
                    Console.WriteLine("." + child);
                    
                }
               else if (node != root)
                {
                    Console.WriteLine(child + "..." + dots);
                }
            }

            //for (Node child : node.children)
            //{
            //    if (node. == root)
            //        printTree(child, ".");
            //    else
            //        printTree(child, "..." + dots);
            //}
        }

        public void PrintTree()
        {
            printTreeCascade(root, ". ");
        }

        private void SortAllChildren()
        {
           
            foreach (var item in treeNodes)
            {
                item.Value.SortChildren();
            }

            root.SortChildren();
        }
    }

    
}
