using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks.Base;

internal abstract class TelegramBotAttack(string botId, long chatId) : Attack("api.telegram.org")
{
    private readonly string BotId = botId;
    private readonly long ChatId = chatId;

    private class TelegramMessage(long ChatId, string Text)
    {
#pragma warning disable IDE1006
        public long chat_id { get; set; } = ChatId;
        public string text { get; set; } = Text;
#pragma warning restore IDE1006
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        yield return new JsonAttackItem<TelegramMessage>($"https://api.telegram.org/bot{BotId}/sendMessage", f => new(ChatId, GetMessage(f)));
    }

    protected abstract string GetMessage(DataBase data);
}
