﻿namespace card_manager_ui.Model;

public class CardDto
{
    public CardDto()
    {
        // intentionally left blank
    }

    public DateTime RegisteringTime { get; set; }
    public string AccountNumber { get; set; }
    public string PIN { get; set; }
    public string SerialNumber { get; set; }
    public string Id { get; set; }
}