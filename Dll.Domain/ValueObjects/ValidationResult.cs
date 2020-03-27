using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.ValueObjects
{
    public class ValidationResult
    {
        public string Success { get; set; }
        public string Error { get; set; }
        public string Info { get; set; }
        public bool IsValid { get; set; }

        public List<Notification> notifications { get; set; }

        public ValidationResult()
        {
            notifications = new List<Notification>();
        }

        public void BuscarMensagens(List<Notification> validateLista, List<Notification> notification)
        {
            foreach (var item in notification)
            {
                validateLista.Add(item);
            }
        }

    }
}
