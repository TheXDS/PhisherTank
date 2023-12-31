namespace TheXDS.PhisherTank.Models;

internal class FormDataAttackItem(string route, Func<DataBase, IEnumerable<KeyValuePair<string, string>>> formCallback) : AttackItem(route)
{
    private static KeyValuePair<string, string> ToKeyValue((string key, string value) tuple)
    {
        return new KeyValuePair<string, string>(tuple.key, tuple.value);
    }

    public FormDataAttackItem(string route, Func<DataBase, IEnumerable<(string key, string value)>> formCallback)
        : this(route, p => formCallback.Invoke(p).Select(ToKeyValue))
    {
    }

    private readonly Func<DataBase, IEnumerable<KeyValuePair<string, string>>> formItems = formCallback;

    public override HttpContent? GetContent(DataBase context)
    {
        return MakeForm(formItems.Invoke(context));
    }

    private static FormUrlEncodedContent MakeForm(IEnumerable<KeyValuePair<string, string>> values)
    {
        return new FormUrlEncodedContent(values.ToArray());
    }
}
