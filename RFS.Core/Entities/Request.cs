using System;
using System.ComponentModel.DataAnnotations;
using RFS.Core.Enums;
namespace RFS.Core
{
    public class Request: AuditableEntity
    {
        [Key]
        public int ID { get; private set; }
        public RequestType Type { get; private set; }
        public Status Status { get; private set; }

        public Request(RequestType type, Status status)
        {
            this.Type = type;
            this.Status = Status;
            this.SetCreated();
        }
        
    }
}
