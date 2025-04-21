using System;

namespace Notes_Client.Models;

public class Note
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}