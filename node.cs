using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_app_converted_java_
{
  public class node
    {
        public node(string input)
        {
            count = 1;
            payload = input;
        }
        public node(){}
        object payload;
        node Lchild;
        node Rchild;
        int count;
        node parent;
       
       public object  getval()
        {
            if ((string)payload == "" ||payload== null) { return null; }
            return payload;    
        }
       public node getLchild()
        {
            if (Lchild == null) { return null; }
            return Lchild;
        }
       public node getRchild()
        {
            if (Rchild == null) { return null; }
            return Rchild;
        }
      public node getparent()
        {
          if (parent == null) { return null; }
          return parent;
        }
       public void setLchild(node leftchild)
        {
            this.Lchild = leftchild;
        }
       public void setRchild(node rightchild)
        {
            this.Rchild = rightchild;
        }
       public void setparent(node Parent)
        {
            this.parent = Parent;
        }
      public void setval(object val)
        {
            this.payload = val;
        }
      public int getcount()
        {
            return this.count;
        }
        public void incrementcount()
        {
            this.count++;
        }
     public void setcount(int newcount)
        {
            this.count = newcount;
        }
     public void clear()
        {
            this.count = 0;
            this.Lchild = null;
            this.parent = null;
            this.Rchild = null;
            this.payload = null;
        }
      public int payloadcompare(string input)
        {
            string payloadstring = (string)payload;
            if (input.CompareTo(payloadstring) == 0)
            {
                return 0;
            }
            else
            {
                return input.CompareTo(payloadstring);
            }
                    
        }    
        
    }
}
