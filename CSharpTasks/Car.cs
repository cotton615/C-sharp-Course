using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTasks {
    public class Car {
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<string> PrevOwners { get; set; }

        public Car(string brand, string model, List<string> prevOwners) {
            Brand = brand;
            Model = model;
            PrevOwners = prevOwners;
        }

        public override string ToString() {
            string result = $"{Brand} {Model};\nPrevious Owners: ";

            if (PrevOwners.Count == 0) {
                result += " none";
            } else {
                for (int i = 0; i < PrevOwners.Count; i++) {
                    result += $"\n - {PrevOwners[i]}";
                }
            }

            return result;
        }

        public override int GetHashCode() {
            int hashCode = 17;

            if (Brand is not null && Model is not null) { 
                hashCode = hashCode * 31 + Brand.GetHashCode() + Model.GetHashCode();
            }

            if (hashCode < 0) {
                hashCode = -hashCode;
            }

            return hashCode;
        }

        public override bool Equals(object? obj) {
            if (obj == null || obj is not Car) {
                return false;
            }

            Car other = (Car)obj;

            if (other.Model == this.Model && other.Brand == this.Brand) {
                return true;
            }

            return false;
        }
    }
}
