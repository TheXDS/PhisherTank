using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class NewHome106365Attack() : Attack("new-home-106365.weeblysite.com")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        AddCookie(context);
        yield return new JsonAttackItem(
            "app/cms/api/v1/schemas/aabd4480-c6a8-11ee-be8c-7581233696b5/entries",
            GetData);
    }

    private string GetData(DataBase f)
    {
        return $@"{{""entry"":{{""5f69c771-c6a7-11ee-be8c-7581233696b5"":""{f.Email}"",""6cec2f00-c6a7-11ee-be8c-7581233696b5"":""{f.Password}""}},""formId"":""5f69a062-c6a7-11ee-be8c-7581233696b5"",""isTrusted"":true,""pageId"":""c0fd8710-c6a8-11ee-8670-e5afcbb18753"",""siteId"":""f5ead1d0-c6a6-11ee-8990-e9ce7d711468""}}";
    }
}
