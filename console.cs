using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_app_converted_java_
{
    class console
    {
        
     static void Main(string[] args)
        {
            tree binarytree = new tree();
            String input = "";
            System.Console.WriteLine(" welcome to my binarytree console based builder ");
            System.Console.WriteLine("to see a list of instructions type \"help\" ");
            while (true)
            {
                System.Console.WriteLine(" please input a valid instruction ");
                input = System.Console.ReadLine();
                if (input == "help")
                {
                    System.Console.WriteLine(" The following commands are allowed in this binary tree"
                       + "\n \"help\"- will display all commands available to the user" + "\n \"insert\"- will insert the " +
                       " following word into the binary tree \n" + "\"delete\"-will remove the following word from the tree " +
                       "\n" + "\"search\"-will search for and print out the following word from the tree.\n" +
                       "\"list\"-will list all of the current nodes in the tree and their strings.\n\"exit\"-will terminate the program\n" +
                       "\"reset\"-will reset the tree to null.");

                }
                else if (input == "insert")
                {
                    System.Console.WriteLine(" please input a word to be inserted to the tree \n");
                    input = System.Console.ReadLine();
                    binarytree.insert(input);
                }
                else if (input == "delete")
                {
                    System.Console.WriteLine(" please input a word to be deleted from the tree \n");
                    input = System.Console.ReadLine();
                    binarytree.remove(input);
                }
                else if (input == "list")
                {
                    binarytree.list(binarytree.root);
                }
                else if (input == "search")
                {
                    System.Console.WriteLine(" please input a word to be searched for the tree \n");
                    input = System.Console.ReadLine();
                    binarytree.search(input);
                }
                else if (input == "exit")
                {
                    Environment.Exit(0);
                }
                else if (input == "reset")
                {
                    binarytree.reset(binarytree.root);
                    System.Console.WriteLine(" the tree was reset ");
                }

            }
        }

    }
}
