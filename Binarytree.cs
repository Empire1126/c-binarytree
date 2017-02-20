using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_app_converted_java_
{
    class tree
    {
        public tree() { root = new node(); }
      public  node selector;
      public node root;
      public  void insert(String input)
        {
            
            if ((string)find(input).getval()!=input)
            {
                node node = new node(input);
                if (root.getval()== null) { root = node; System.Console.WriteLine(" the word \"" + (string)node.getval() + "\" was added to the list with a count of 1 "); return; }
                else if (selector.payloadcompare(input) < 0)
                {
                    selector.setLchild(node);
                    System.Console.WriteLine(" the word \"" + (string)node.getval() + "\" was added to the list with a count of 1 " +
                        "to the left of \"" + (string)selector.getval()+"\"\n");
                    
                }
                else if(selector.payloadcompare(input) >0)
                {
                    selector.setRchild(node);
                    System.Console.WriteLine(" the word \"" + (string)node.getval() + "\" was added to the list with a count of 1 " +
                       "to the right of \"" + (string)selector.getval() + "\"\n");
                    
                }
                node.setparent(selector);
             }
            else
            {
                selector.incrementcount();
                System.Console.WriteLine(" the word \"" + (string)selector.getval() + "\" had its count incremented \n");
            }
        }
        node find(string input)
        {
            selector = root;
            while (selector.getRchild() != null||selector.getLchild()!=null)
            {
                if ((string)selector.getval() == input)
                {
                    return selector;
                }
                else if (selector.getLchild()!=null&&selector.payloadcompare(input) < 0)
                {
                    selector = selector.getLchild();
                    continue;
                }
                else if(selector.getRchild()!=null)
                {
                    selector = selector.getRchild();
                    continue;
                }
            }

            return selector;
        }
       public void search(string input)
        {
            node temp = find(input);
            if (temp == null)
            {
                System.Console.WriteLine(" the string you were looking for is not in the tree \n");
                return;
            }
            else
            {
                System.Console.WriteLine(" the string you were searching for is \"" + (string)temp.getval() + "\"with a count of " + temp.getcount()+"\n");
                return;
            }
        }
      public  node list(node currentnode)
        {
            if (currentnode.getLchild() != null)
            {
                list(currentnode.getLchild());
               
            }
            if(currentnode.getRchild()!=null)
            {
                list(currentnode.getRchild());
            }
            System.Console.WriteLine(" the node \"" + (string)currentnode.getval() + "\" exists in the tree with a count of " + currentnode.getcount());
            return currentnode;
        }
        public void remove(string input)
        {
            node temp = find(input);

            if ((string)temp.getval() != input) { System.Console.WriteLine(" the word you wanted to delete is not in the tree \n"); return; }

            if (root == temp)
            {
                if (temp.getLchild() == null && temp.getRchild() == null)
                {
                    System.Console.WriteLine(" the root \"" + (string)root.getval() + "\" was deleted");
                    root.setval("");
                    root.setcount(0);
                }
                else if (temp.getLchild().getRchild() == null)
                {
                    temp = temp.getLchild();
                    transplant(temp, 2);
                }
                else if(temp.getRchild().getLchild()==null)
                {
                    temp = temp.getRchild();
                    transplant(temp, 3);
                }
            }
            else if (temp.getRchild() != null)
            {
                temp = temp.getRchild();
                transplant(temp, 1);
            }
            else if (temp.getLchild() != null)
            {
                temp = temp.getLchild();
                transplant(temp, 0);

            }
            else
            {
                transplant(temp, 4);
            }

           
        }
        void transplant(node top, int type)
        {
            selector = top;

            if (type == 0)
            {
                while (selector.getRchild() != null)
                {
                    selector = selector.getRchild();
                }
                System.Console.WriteLine(" the word \"" + (string)top.getparent().getval() + "\" was deleted from the tree \n");
                top.getparent().setval(selector.getval());
                top.getparent().setcount(selector.getcount());
                selector.getLchild().setparent(selector.getparent());
                
                selector = selector.getparent();
                selector.setRchild(selector.getRchild().getLchild());

            }
            else if (type == 1)
            {
                while (selector.getLchild() != null)
                {
                    selector = selector.getLchild();
                }
                System.Console.WriteLine(" the word \"" + (string)top.getparent().getval() + "\" was deleted from the tree \n");
                top.getparent().setval(selector.getval());
                top.getparent().setcount(selector.getcount());
                selector.getRchild().setparent(selector.getparent());
                
                selector = selector.getparent();
                selector.setLchild(selector.getLchild().getRchild());

            }
            else if (type == 2)
            {
                System.Console.WriteLine(" the root \"" + (string)root.getval() + "\" was deleted");
                if (top.getparent().getRchild() != null)
                {

                    top.getparent().getRchild().setparent(top);
                    top.setRchild(top.getparent().getRchild());
                    root = top;
                    top.setparent(null);
                    return;
                }
                else
                {
                    root = top;
                    top.setparent(null);
                }

            }
            else if (type == 3)
            {
                System.Console.WriteLine(" the root \"" + (string)root.getval() + "\" was deleted");
                if (top.getparent().getLchild() != null)
                {
                    top.getparent().getLchild().setparent(top);
                    top.setLchild(top.getparent().getLchild());
                    root = top;
                    top.setparent(null);
                    return;
                }
                else
                {
                    root = top;
                    top.setparent(null);
                }
            }
            else 
            {
                System.Console.WriteLine(" the word \"" + top.getval() + "\" was deelted from the list ");
                if (top.payloadcompare((string)top.getparent().getval()) < 0)
                {
                    top = top.getparent();
                    top.getparent().setRchild(null);
                }
                else
                {
                    top = top.getparent();
                    top.getparent().setLchild(null);
                }
                

          }  
        }
        public node reset(node key)
        {
            if (key.getLchild() != null)
            {

                reset(key.getLchild());
                key.setLchild(null);
            }
            if (key.getRchild()!=null)
            {
                reset(key.getRchild());
                key.setRchild(null);
            }
            key.setparent(null);
            return key;
        }
        
    }
}
