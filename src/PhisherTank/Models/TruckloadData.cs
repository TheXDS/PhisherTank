namespace ConsoleApp1.Models;

internal class TruckloadData(int size) : GarbageDataBase(size)
{
    public TruckloadData() : this(64000)
    {
    }
}
