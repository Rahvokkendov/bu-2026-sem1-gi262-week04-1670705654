using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            //[Done]AS01_CountWords();
            //[Done]AS02_CountNumber();
            //[Done]AS03_CheckValidBrackets();
            //[Done]AS04_PrintReverseLinkedList();
            //[Done]AS05_FindMiddleElement();
            //[Done]AS06_MergeDictionaries();
            //[Done]AS07_RemoveDuplicatesFromLinkedList();
            //[Done]AS08_TopFrequentNumber();
            //[Done]AS09_PlayerInventory();
            //[Done]AS10_GameEventQueue();
            AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string, int> wordsFound = new Dictionary<string, int>();

            for (int i = 0; i < words.Length;i++)
            {
                string countedWord = words[i];
                if (wordsFound.ContainsKey(countedWord))
                {
                    wordsFound[countedWord]++;
                }
                else
                {
                    wordsFound.Add(countedWord, 1);
                }
            }
            foreach(KeyValuePair<string,int> kvp in wordsFound)
            {
                Debug.Log($"Word: {kvp.Key}, Count: {kvp.Value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int, int> numbersFound = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int countedNum = numbers[i];
                if (numbersFound.ContainsKey(countedNum))
                {
                    numbersFound[countedNum]++;
                }
                else
                {
                    numbersFound.Add(countedNum, 1);
                }
            }
            foreach(KeyValuePair<int, int> kvp in numbersFound)
            {
                Debug.Log($"Numbers: {kvp.Key}, Count: {kvp.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> bracketPair = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            LinkedList<char> stack = new LinkedList<char>();
            foreach(char c in input)
            {
                if (bracketPair.ContainsKey(c))
                {
                    stack.AddLast(c);
                }
                else if(bracketPair.ContainsValue(c))
                {
                    if(stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                    else
                    {
                        char letter = stack.Last.Value;
                        if(c == bracketPair[letter])
                        {
                            stack.Remove(letter);
                        }
                        else
                        {
                            Debug.Log("Invalid");
                            return;
                        }
                    }
                }
            }
            Debug.Log(stack.Count == 0 ? "Valid" : "Invalid");
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            if(list.Count == 0)
            {
                Debug.Log("List is Empty");
                return;
            }
            var currentNode = list.Last;
            while(currentNode != null)
            {
                Debug.Log(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;
            if(list.Count == 0)
            {
                Debug.Log("List is Empty");
                return;
            }

            while(fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            Dictionary<string, int> mergeDict = dict1;
            
            foreach(KeyValuePair<string,int> kvp in dict2)
            {
                if(mergeDict.ContainsKey(kvp.Key))
                {
                    mergeDict[kvp.Key] += kvp.Value;
                }
                else
                {
                    mergeDict.Add(kvp.Key, kvp.Value);
                }
            }

            foreach(KeyValuePair<string,int> kvpTwo in mergeDict)
            {
                Debug.Log($"Key: {kvpTwo.Key}, Value: {kvpTwo.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            Dictionary<int,bool> duplicatedNumDict = new Dictionary<int,bool>();
            LinkedListNode<int> currentNum = list.First;
            while(currentNum != null)
            {
                LinkedListNode<int> nextNode = currentNum.Next;
                if(duplicatedNumDict.ContainsKey(currentNum.Value))
                {
                    list.Remove(currentNum.Value);
                }
                else
                {
                    duplicatedNumDict.Add(currentNum.Value, true);
                }
                currentNum = nextNode;
            }

            foreach (KeyValuePair<int, bool> kvp in duplicatedNumDict)
            {
                Debug.Log($"{kvp.Key}");
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            Dictionary<int,int> numFreqDict = new Dictionary<int,int>();
            if(numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
            }
            else
            {
                for(int i = 0; i < numbers.Length; i++)
                {
                    if (numFreqDict.ContainsKey(numbers[i]))
                    {
                        numFreqDict[numbers[i]]++;
                    }
                    else
                    {
                        numFreqDict.Add(numbers[i], 1);
                    }
                }
                int mostFreq = numbers[0];
                int maxCount = numFreqDict[mostFreq];

                foreach (int i in numbers)
                {
                    int currentNumCount = numFreqDict[i];
                    if (currentNumCount > maxCount)
                    {
                        mostFreq = i;
                        maxCount = currentNumCount;
                    }
                }
                Debug.Log($"{mostFreq} Count: {maxCount}");
            }

        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
            if(inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory.Add(itemName, quantity);
            }
            foreach (KeyValuePair<string, int> kvp in inventory)
            {
                Debug.Log($"Inventory = {kvp.Key}, Quantity: {kvp.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if(eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
            }
            else
            {
                while (eventQueue.Count > 0)
                {
                    var firstEvent = eventQueue.First.Value;
                    eventQueue.RemoveFirst();
                    Debug.Log($"processing event: {firstEvent.Name}, Remaining events in queue: {eventQueue.Count}, {firstEvent.EventType} event processed");
                }
            }

        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats.Add(statName, value);
            }
            Debug.Log($"Updated {statName}: {value}");
            Debug.Log($"Current player statistic: ");

            foreach (KeyValuePair<string,int> kvp in playerStats)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        #endregion
    }
}
