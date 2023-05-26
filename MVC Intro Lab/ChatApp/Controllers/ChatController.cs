namespace ChatApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using ViewModels;

public class ChatController : Controller
{
    /// <summary>
    /// Store the messages into a list of KVP..BAD IDEA
    /// Don't wanna use DB for so simple app
    /// </summary>
    private static List<KeyValuePair<string, string>> _messages =
        new List<KeyValuePair<string, string>>();

    [HttpGet]
    public IActionResult Show()
    {
        if (!_messages.Any())
        {
            return View(new ChatViewModel());
        }

        var chatModel = new ChatViewModel()
        {
            Messages = _messages
                .Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                })
                .ToList()
        };

        return View(chatModel);
    }

    [HttpPost]
    public IActionResult Send(ChatViewModel chat)
    {
        var newMessage = chat.CurrentMessage;

        _messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

        return RedirectToAction("Show");
    }
}