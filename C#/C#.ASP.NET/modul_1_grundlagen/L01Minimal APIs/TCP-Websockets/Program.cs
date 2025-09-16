// Ein einfacher Datenspeicher (f�rs Beispiel, sp�ter w�re das eine Datenbank)

// verwende https://piehost.com/websocket-tester um an einen websocket daten zu senden.

using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// *** NEU: WebSocket Konfiguration ***
app.UseWebSockets();

// Ein Endpunkt, der nur auf WebSocket-Anfragen reagiert
app.Map("/ws", async context =>
{
    // Pr�fen, ob es sich um eine WebSocket-Anfrage handelt
    if (context.WebSockets.IsWebSocketRequest)
    {
        // Verbindung annehmen
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();

        // Puffer f�r empfangene Daten
        var buffer = new byte[1024 * 4];

        // Endlosschleife, um auf Nachrichten zu lauschen
        while (webSocket.State == System.Net.WebSockets.WebSocketState.Open)
        {
            // Auf eine Nachricht vom Client warten
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            // Wenn der Client die Verbindung schlie�t
            if (receiveResult.MessageType == System.Net.WebSockets.WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(
                    receiveResult.CloseStatus.Value,
                    receiveResult.CloseStatusDescription,
                    CancellationToken.None);
                break;
            }

            // Die empfangene Nachricht als "Echo" zur�ck an den Client senden
            await webSocket.SendAsync(
                new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                receiveResult.MessageType,
                receiveResult.EndOfMessage,
                CancellationToken.None);
        }
    }
    else
    {
        // Wenn jemand mit einem normalen Browser auf /ws geht
        context.Response.StatusCode = 400; // Bad Request
    }
});

app.Run();