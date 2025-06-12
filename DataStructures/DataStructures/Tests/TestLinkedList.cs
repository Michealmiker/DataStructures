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
    
    private static void PrintListInfo()
    {
        Console.WriteLine("表信息：");
        Console.WriteLine($"表长度：{_linkedList.Count}");
        Console.WriteLine($"表内容:\n{_linkedList}");
    }
}