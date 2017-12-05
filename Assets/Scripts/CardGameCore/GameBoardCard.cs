﻿using Newtonsoft.Json;
using System.Collections.Generic;

[JsonObject(MemberSerialization.OptIn)]
public class GameBoardCard
{
    [JsonProperty]
    public string Card { get; private set; }

    [JsonProperty]
    public List<GameBoard> Boards { get; private set; }
}
