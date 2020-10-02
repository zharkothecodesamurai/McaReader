
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace NodeCreate
{
    public class Node:IComparable<Node>
    {
        public int ID;
        public string MenuName;
        public int ParentID;
        public bool IsHidden;
        public string LinkUrl;
        public List<Node> children;

        public int CompareTo([AllowNull] Node other)
        {
            return MenuName.CompareTo(other.MenuName);
        }

        public override string ToString()
        {
            return MenuName;
        }
      
        public Node (string value)
        {
            String[] splittedLine = value.Split(';');
//ova treba da se fati vo try catch preku metod da go povikam 
            ID = Int32.Parse(splittedLine[0]);
            MenuName = splittedLine[1];
            ParentID = splittedLine[2] != "NULL" ? Convert.ToInt32(splittedLine[2]) : 0; 
            IsHidden = bool.Parse(splittedLine[3]);
            LinkUrl = splittedLine[4];
            
            children = new List<Node>();
        }
            
           
        

        public Node()
        {
            IsHidden = true;
            children = new List<Node>();
        }

        public void addChild(Node node)
        {
            children.Add(node);
        }

        
        public  void SortChildren()
            
        {

            children.OrderBy(item=>item.CompareTo(item));

        }  
    }
}
