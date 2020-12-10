using System;
using System.Collections.Generic;
using ValueObjects.Extensions;

namespace ValueObjects
{
    public class Team : ValueObject
    {
        public string Name { get; }
        public string NameIdentifier { get; }

        public Team(string name, string nameIdentifier)
        {
            _ = name.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(name));
            _ = nameIdentifier.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(nameIdentifier));

            Name = name;
            NameIdentifier = nameIdentifier.ToUpper();
        }

        public override string ToString() => NameIdentifier;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return NameIdentifier;
        }
    }
}