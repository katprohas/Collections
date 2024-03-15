using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Reflection;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
        //Begin QUEUE COLLECTION
            //Use the Queue<T> collection.
            Console.WriteLine("---------------------------");
            Console.WriteLine("QUEUE COLLECTION");
            Console.WriteLine("---------------------------");

            Queue<string> animals = new Queue<string>();

            //Add 5 items.
            animals.Enqueue("Dogs");
            animals.Enqueue("Cats");
            animals.Enqueue("Rabbits");
            animals.Enqueue("Fish");
            animals.Enqueue("Axolotls");
            //Check to see if the queue contains a specific item and display a message. (Do not remove this item from the queue.)
            Console.WriteLine("Does the queue contain 'Fish'?");
            bool queueHas = animals.Contains("Fish");
            if (queueHas == false)
            {
                Console.WriteLine("That is not in the queue");
            }
            else
            {
                Console.WriteLine("That is in the queue");
            }
            
            //Remove at least 1 different item from the queue.
            string firstAnim = animals.Peek();
            Console.WriteLine($"Removing {firstAnim} from the queue... {animals.Dequeue()} have been removed.");
            
            //Count the items in the queue and display the count.
            int animCount = animals.Count();
            Console.WriteLine($"There are {animCount} animal(s) in the queue");

            Console.WriteLine("The following animals are currently in the queue: ");
            //Print all the items in the queue.
            foreach ( var anim in animals ) 
            {
                Console.WriteLine(anim);
            }
            
            Console.ReadLine();
        //End QUEUE COLLECTION

            //Begin PRIORITY QUEUE COLLECTION
            //Use the PriorityQueue<T> collection
            Console.WriteLine("---------------------------");
            Console.WriteLine("***PRIORITY*** QUEUE COLLECTION");
            Console.WriteLine("---------------------------");

            PriorityQueue<string, int> favBooks= new PriorityQueue<string, int>();

            //Add 5 items.
            favBooks.Enqueue("Stardust", 1);
            favBooks.Enqueue("The Book Thief", 2);
            favBooks.Enqueue("Throne of Glass", 3);
            favBooks.Enqueue("The Bees", 4);
            favBooks.Enqueue("The Girl Who Drank the Moon", 5);

            //Find and display the highest priority item, then remove the item.
            favBooks.TryPeek(out string nextBook, out int BookPriority);
            Console.WriteLine($"Highest priority book: {nextBook}");
            favBooks.TryDequeue(out string bookRead, out int readPriority);
            Console.WriteLine($"Highest priority book '{bookRead}' has now been read and removed. Priority was {readPriority}.");
            
            //Continue displaying the highest priority item and removing it until all items are removed.
            //for ( int i = 0; i < favBooks.Count; i++ )
            while(favBooks.Count > 0)
            {

            
                if (favBooks.Count == 0)
                {
                    Console.WriteLine("There are no more items in the queue");
                }
                else 
                {
                    //favBooks.TryPeek(out string bookNext, out int bookPrior);
                    //Console.WriteLine($"Highest priority book: {bookNext}");
                    favBooks.TryDequeue(out string bookDone, out int donePrior);
                    Console.WriteLine($"Highest priority book '{bookDone}' has now been read and removed. Priority was {donePrior}.");
                }

            }
            Console.ReadLine();
        //End PRIORITY QUEUE COLLECTION

        //Begin STACK COLLECTION
            //Use the Stack<T> collection.
            Console.WriteLine("---------------------------");
            Console.WriteLine("STACK COLLECTION");
            Console.WriteLine("---------------------------");
            
            Stack<string> weather = new Stack<string>();

            //Add 5 items.
            weather.Push("sunshine");
            weather.Push("partly cloudy");
            weather.Push("rain");
            weather.Push("snow");
            weather.Push("overcast");

            //Check to see if the stack contains a specific item and display a message.
            Console.WriteLine("Checking to see if the stack contains: 'snow'"); 
            if (weather.Contains("snow"))
            {
                Console.WriteLine("That element is in the stack.");
            }
            else                    
                Console.WriteLine("That element is not in the stack.");

            //Remove at least 1 item.
            Console.WriteLine($"Removing the topmost item of the stack...'{weather.Pop()}' has been removed.");

            //Count the items in the stack and display the count.
            Console.WriteLine($"There are currently {weather.Count()} items in the stack.");

            //Print all the items in the stack.
            Console.WriteLine("Printing all current items in the stack...");
            foreach(string w in weather)
            {
                Console.WriteLine(w);
            }
            Console.ReadLine();

        //End STACK COLLECTION

        //Begin LINKED LIST COLLECTION
            //Use the LinkedList<T> and LinkedNodeList<T> collections.
            Console.WriteLine("---------------------------");
            Console.WriteLine("LINKED LIST COLLECTION");
            Console.WriteLine("---------------------------");
            
            //Add 5 items to a linked list.
            string[] characters = {"Fry", "Bender", "Leela", "Hermes", "Nibbler"};
            LinkedList<string> characterList = new LinkedList<string>(characters);

            //Retrieve and display the first node.
            Console.WriteLine($"First node: {characterList.First()}");

            //Retrieve and display the last node.
            Console.WriteLine($"Last node: {characterList.Last()}");

            //Add a 6th item to the middle of the list.
            LinkedListNode<string> target = characterList.Find("Leela");
            characterList.AddAfter(target, "Amy");

            //Remove a node from the list(it can be the first, last, or a node with a specific value).
            characterList.RemoveLast();

            //Count the items in linked list and display the count.
            Console.WriteLine($"There are {characterList.Count()} items in the list");

            //Print all the items in the linked list.
            Console.WriteLine("Printing final character list...");
            foreach (var c in characterList)
            {
                Console.WriteLine(c);
            }
            Console.ReadLine();
        //End LINKED LIST COLLECTION

        //Begin DICTIONARY COLLECTION
            Console.WriteLine("---------------------------");
            Console.WriteLine("DICTIONARY COLLECTION");
            Console.WriteLine("---------------------------");
            
            Dictionary<string,string> nameList = new Dictionary<string,string>();

            //Add 5 items to a dictionary
            nameList.Add("John", "Doe");
            nameList.Add("Jane", "Deer");
            nameList.Add("Stephen", "King");
            nameList.Add("Neil", "Gaiman");
            nameList.Add("Arnold", "Palmer");

            //Retrieve and display all the keys
            Console.WriteLine("Retrieving all keys (first names)...");
            Dictionary<string, string>.KeyCollection keys = nameList.Keys;
            foreach (string k in keys)
            {
                Console.WriteLine($"Key: {k}");
            }

            //Retreive and display all the values
            Console.WriteLine("\nRetrieving all values (last names)...");
            Dictionary<string, string>.ValueCollection value = nameList.Values;
            foreach (string v in value)
            {
                Console.WriteLine($"Value: {v}");
            }

            //Retrieve and display both the keys and the values
            Console.WriteLine("\nPrinting both key and value pairs...");
            foreach(KeyValuePair<string, string> pair in nameList)
            {
                Console.WriteLine($"Key: {pair.Key}  Value: {pair.Value}");
            }

            //Remove an item from the dictionary
            nameList.Remove("Jane");
            Console.WriteLine("\nFinal list: ");
            foreach (KeyValuePair<string, string> pair in nameList)
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }

            //Display a count of the dictionary items.
            Console.WriteLine($"\nFinal count: {nameList.Count()}");
            Console.ReadLine();
        //End DICTIONARY COLLECTION

        //Begin SORTEDLIST COLLECTION
            Console.WriteLine("---------------------------");
            Console.WriteLine("SORTED LIST COLLECTION");
            Console.WriteLine("---------------------------");
            
            SortedList<int, string> classList = new SortedList<int, string>();
            
            //Add 5 items to a sorted list
            classList.Add(1, "English");
            classList.Add(2, "Math");
            classList.Add(3, "Econ");
            classList.Add(4, "Gym");
            classList.Add(5, "Study Period");

            //Allow the user to enter a key and value(you will need to check to see if the key exists and handle the problem)
            //Remove an item from the list
            Console.WriteLine("Please enter a new class period number: (1, 2, etc.)");
            int classPeriod = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a new class name: ");
            string className = Console.ReadLine();

            if (classList.ContainsValue(className))
            {
                Console.WriteLine($"{className} class is already in your list");
            }
            else
            {
                if (classList.ContainsKey(classPeriod))
                {
                    Console.WriteLine("You can only have one class in each class period.");
                    classList.Remove(classPeriod);
                    classList.Add(classPeriod, className);
                    Console.WriteLine($"Your current class name has been removed and  has been added");
                }
                else
                {
                    classList.Add(classPeriod, className);
                    Console.WriteLine($"{className} in period {classPeriod} were added to your list");
                }
            }

            //Print the key and value for your sorted list.
            Console.WriteLine("Class list looks like: ");
            foreach(KeyValuePair<int, string> pair in classList)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }
            Console.ReadLine();
        //End SORTEDLIST COLLECTION

        //Begin HASHSET COLLECTION
            Console.WriteLine("---------------------------");
            Console.WriteLine("HASHSET COLLECTION");
            Console.WriteLine("---------------------------");
            
            HashSet<string> romanceLanguages = new HashSet<string>();

            //Add 5 items to a hashset object
            romanceLanguages.Add("Portugese");
            romanceLanguages.Add("Spanish");
            romanceLanguages.Add("Italian");
            romanceLanguages.Add("French");
            romanceLanguages.Add("Romanian");            

            //Create a similar hashset object with 5 items.
            HashSet<string> germanicLanguages = new HashSet<string>();
            germanicLanguages.Add("English");
            germanicLanguages.Add("German");
            germanicLanguages.Add("Dutch");
            germanicLanguages.Add("Afrikaans");
            germanicLanguages.Add("Swedish");

            //Create a third hashset object and add 5 more items(2 items should be the same as your first or second object)
            HashSet<string> otherLanguages = new HashSet<string>();
            otherLanguages.Add("Mandarin");
            otherLanguages.Add("Korean");
            otherLanguages.Add("English");
            otherLanguages.Add("Vietnamese");
            otherLanguages.Add("Italian");

            //Use a command to combine the first and second object.Store the combined items in the first object and print out the combined list.
            Console.WriteLine("Combined list of romance and germanic languages: ");
            romanceLanguages.UnionWith(germanicLanguages);
            foreach(string l in romanceLanguages)
            {
                Console.WriteLine(l);
            }

            //Create a new hashset object to store duplicates and use a command to display items that appear in both the first object and your third object.Store the results in your new hashset object.Print out the contents of the object
            Console.WriteLine("\nDuplicate languages: ");
            HashSet<string> dupes = new HashSet<string>();
            dupes = romanceLanguages;
            dupes.IntersectWith(otherLanguages);
            foreach(string l in dupes)
            { Console.WriteLine(l); }
            Console.ReadLine();
        //End HASHSET COLLECTION

        //Begin LIST COLLECTION
            Console.WriteLine("---------------------------");
            Console.WriteLine("LIST COLLECTION");
            Console.WriteLine("---------------------------");
            //Add 5 items to a list
            List<int> scores = new List<int>() {20,30,40,50,10};

            //Use the AddRange() method to add 3 more items to a list
            int[] moreScores = new int[] { 77, 88, 99 };
            scores.AddRange(moreScores);

            //Sort the list and print all the items
            scores.Sort();
            for (int i=0; i < scores.Count(); i++) {
                Console.WriteLine(scores[i]); 
            }
            //Remove at least 1 item
            scores.RemoveAt(3);
            Console.WriteLine($"Removing a number at index 3...");
            //Sort the list in reverse order and print all items.
            scores.Sort();
            scores.Reverse();
            Console.WriteLine($"Printing the sorted list in reverse order...");
            for (int i = 0; i < scores.Count(); i++)
            {
                Console.WriteLine(scores[i]);
            }
        //End LIST COLLECTION

        } // end main method
    } //end program class

} //end namespace
