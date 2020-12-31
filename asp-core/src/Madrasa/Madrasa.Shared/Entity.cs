using System;
using System.Collections.Generic;
using System.Text;

namespace Madrasa.Shared.Generic
{
    public abstract class BaseEntity
    { }
    public class Entity<T> : BaseEntity
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
