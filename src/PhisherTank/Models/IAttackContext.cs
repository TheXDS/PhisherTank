﻿namespace TheXDS.PhisherTank.Models;

internal interface IAttackContext : IDisposable
{
    HttpResponseMessage? LastResponse { get; }

    Dictionary<string, string> Headers { get; }

    DataBase Data { get; }

    bool Failed { get; set; }
}
