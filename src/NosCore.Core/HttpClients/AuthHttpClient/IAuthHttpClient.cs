﻿namespace NosCore.Core.HttpClients.AuthHttpClient
{
    public interface IAuthHttpClient
    {
        bool IsAwaitingConnection(string name, string packetPassword, int clientSessionSessionId);
    }
}