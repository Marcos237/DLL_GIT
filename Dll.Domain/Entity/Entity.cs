using Dll.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Entity
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public ValidationResult validateResult { get; set; }

        public Entity(int id)
        {
            Id = id;
        }
        public Entity()
        {
            validateResult = new ValidationResult();
        }
    }
}
