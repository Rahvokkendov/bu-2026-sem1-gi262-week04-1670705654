using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            //LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            LCT03_SyntaxHashTable();
            //LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {

            LinkedList<string> linkedList = new LinkedList<string>();

            //[Node 1] -> null
            linkedList.AddLast("Node 1");

            //[Node 1] -> [Node 2] -> null
            linkedList.AddLast("Node 2");

            //[Node 0] -> [Node 1] -> [Node 2] -> null
            linkedList.AddFirst("Node 0");

            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Value);
            Debug.Log(node1.Next.Value);
            Debug.Log(node1.Previous.Value);

            Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            var firstNode = linkedList.First;
            var secondNode = linkedList.Last;
         
            Debug.Log(firstNode.Previous);
            Debug.Log(secondNode.Next);
            Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

            linkedList.AddAfter(node1,"Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");

            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            linkedList.Remove("Node 1.5");

            linkedList.Clear();

            foreach (var item in linkedList)
            {
                Debug.Log(item);
            }
        }

        public void LCT02_SyntaxLinkedList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT03_SyntaxHashTable()
        {
            Hashtable table = new Hashtable();
            table.Add("Potion", 5);
            table.Add(5, "Potion");

            foreach (var item in table)
            {
                Debug.Log($"{item}");
            }
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> inv = new Dictionary<string, int>();

            inv.Add("Skooma", 5);
            inv.Add("Moon Sugar", 10);
            inv.Add("Cheese Wheel", 500);

            inv["Cheese Wheel"] += 900;

            int skooma = inv["Skooma"];
            int cheese = inv["Cheese Wheel"];
            Debug.Log("potion: " + skooma);
            Debug.Log("cheese: " + cheese);

            bool hasSkooma = inv.ContainsKey("Skooma");
            Debug.Log("hasSkooma: " + hasSkooma);

            inv.Remove("Moon Sugar");

            foreach(KeyValuePair<string, int> kvp in inv)
            {
                var key = kvp.Key;
                var value = kvp.Value;

                Debug.Log($"{key}, {value}");
            }

            inv.Clear();
        }

        #endregion
    }
}
