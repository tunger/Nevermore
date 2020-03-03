﻿using Nevermore.Contracts;
using Octopus.TinyTypes;

namespace Nevermore.IntegrationTests.Model
{
    public class Machine : IDocument
    {
        public MachineId Id { get; protected set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public Endpoint Endpoint { get; set; }
    }

    public class MachineId: CaseSensitiveTypedString
    {
        public MachineId(string value) : base(value)
        {
        }
    }

    public abstract class Endpoint
    {
        public string Name { get; set; }

        public abstract string Type { get; }
    }

    public class PassiveTentacleEndpoint : Endpoint
    {
        public override string Type => "PassiveTentacle";
    }
    public class ActiveTentacleEndpoint : Endpoint
    {
        public override string Type => "ActiveTentacle";
    }
}