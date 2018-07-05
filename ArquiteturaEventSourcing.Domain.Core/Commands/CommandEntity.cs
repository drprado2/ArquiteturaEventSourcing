using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Commands
{
    public class CommandEntity
    {
        public CommandEntity()
        {
            Id = Guid.NewGuid();
            Time = DateTime.Now.Ticks;
        }

        [JsonProperty]
        public Guid Id { get; protected set; }

        [JsonProperty]
        public long Time { get; protected set; }

        [JsonProperty]
        public string CommandSerialized { get; protected set; }

        public void SetSerializationCommand(string jsonSerialization)
        {
            CommandSerialized = jsonSerialization;
        }
    }
}
