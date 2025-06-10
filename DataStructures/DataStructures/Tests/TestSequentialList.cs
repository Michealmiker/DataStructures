namespace DataStructures.Tests;

public static class TestSequentialList
{
    private static SequentialList<int> _seqList = new();

    public static void TestAdd()
    {
        for (var i = 0; i < 10; i++)
        {
            _seqList.Add(i + 1);
        }

        PrintListInfo();
    }

    public static void TestAddFirst()
    {
        for (var i = 0; i < 10; i++)
        {
            _seqList.AddFirst(i + 1);
        }
        
        PrintListInfo();
    }

    public static void TestInsert()
    {
        for (var i = 0; i < 10; i++)
        {
            _seqList.Add(i + 1);
        }

        var rand = new Random();
        for (var i = 0; i < 10; i++)
        {
            var index = rand.Next(0, _seqList.Count);
            var number = rand.Next(500, 600);
            
            _seqList.Insert(index, number);
            
            Console.WriteLine($"向表第{index + 1}位置插入新元素{number}");
        }
        
        PrintListInfo();
    }

    public static void TestIndexOf()
    {
        for (var i = 0; i < 10; i++)
        {
            _seqList.Add(i + 1);
        }
        
        var location = _seqList.IndexOf(5);
        var location2 = _seqList.IndexOf(1000);
        
        Console.WriteLine($"10在表中的位置为{location}");
        Console.WriteLine($"1000在表中的位置为{location2}");

        PrintListInfo();
    }

    public static void TestRemove()
    {
        for (var i = 0; i < 10; i++)
        {
            _seqList.Add(i + 1);
        }
        
        _seqList.Remove(5);
        
        PrintListInfo();
    }

    public static void TestRemoveAt()
    {
        for (var i = 0; i < 10; i++)
        {
            _seqList.Add(i + 1);
        }
        
        _seqList.RemoveAt(5);
        
        PrintListInfo();
    }

    public static void TestEnumerate()
    {
        for (var i = 0; i < 10; i++)
        {
            _seqList.Add(i + 1);
        }
        
        foreach (var item in _seqList)
        {
            Console.WriteLine(item);
        }
    }

    private static void PrintListInfo()
    {
        Console.WriteLine("表信息：");
        Console.WriteLine($"表容量：{_seqList.Capacity}");
        Console.WriteLine($"表长度：{_seqList.Count}");
        Console.WriteLine($"表内容:\n{_seqList}");
    }
}