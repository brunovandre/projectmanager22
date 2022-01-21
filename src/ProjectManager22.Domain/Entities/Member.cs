using System;

namespace ProjectManager22.Domain.Entities
{
    public class Member : Entity
    {
        protected Member() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Role { get; private set; }

        public Member(string name, string role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Role = role;
        }
    }
}
