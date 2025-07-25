using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTasks {
    public abstract class Entity {
        public string Name { get; private set; }

        public Entity(string name) {
            Name = name;
        }

        public bool Attack(Entity enemy) {
            if (enemy == this) {
                throw new InvalidOperationException("Entity cannot attack itself.");
            }

            return true;
        }
    }
}
