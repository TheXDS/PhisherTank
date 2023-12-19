using TheXDS.PhisherTank.Component;

namespace TheXDS.PhisherTank.Models;

public class UsFauxData : FauxData
{
    public UsFauxData()
    {
        Address = MiscFaker.GetUsaAddress();
    }
}