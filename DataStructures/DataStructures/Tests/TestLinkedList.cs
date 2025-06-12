namespace DataStructures.Tests;

public static class TestLinkedList
{
    private static Linear.List.LinkedList<int> _linkedList = new();

    public static void TestAdd()
    {
        for (var i = 0; i < 10; i++)
        {
            _linkedList.Add(i + 1);
        }

        PrintListInfo();
    }

    public static void TestAddFirst()
    {
        for (var i = 0; i < 10; i++)
        {
            _linkedList.AddFirst(i + 1);
        }
        
        PrintListInfo();
    }

    public static void TestInsert()
    {
        for (var i = 0; i < 10; i++)
        {
            _linkedList.Add(i + 1);
        }

        var rand = new Random();
        for (var i = 0; i < 10; i++)
        {
            var index = rand.Next(0, _linkedList.Count);
            var number = rand.Next(500, 600);
            
            _linkedList.Insert(index, number);
            
            Console.WriteLine($"向表第{index + 1}位置插入新元素{number}");
        }
        
        PrintListInfo();
    }
    
    public static void TestIndexOf()
    {
        for (var i = 0; i < 10; i++)
        {
            _linkedList.Add(i + 1);
        }
        
        var location = _linkedList.IndexOf(5);
        var location2 = _linkedList.IndexOf(1000);
        
        Console.WriteLine($"10在表中的位置为{location}");
        Console.WriteLine($"1000在表中的位置为{location2}");

        PrintListInfo();
    }
    
    private static void PrintListInfo()
    {
        Console.WriteLine("表信息：");
        Console.WriteLine($"表长度：{_linkedList.Count}");
        Console.WriteLine($"表内容:\n{_linkedList}");
    }
}