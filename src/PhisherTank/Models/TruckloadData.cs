namespace TheXDS.PhisherTank.Models;

public class TruckloadData(int size) : GarbageDataBase(size)
{
    public TruckloadData() : this(64000)
    {
    }
}
