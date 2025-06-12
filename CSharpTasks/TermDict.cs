using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTasks {
    public class TermDict {

        private Dictionary<string, string> _termsDict = new Dictionary<string, string>();

        // Methods

        /// <summary>
        /// Adds term to the dictionary.
        /// </summary>
        /// <param name="name">Name of the term.</param>
        /// <param name="definition">Definition of the term.</param>
        /// <exception cref="ArgumentException">Throws ArgumentException if name or definition is blank.</exception>
        /// <exception cref="InvalidOperationException">Throws InvalidOperationException if term already exists</exception>
        public void Add(string name, string definition) {
            if (name == "" || definition == "") {
                throw new ArgumentException("Термин или его определение не могут быть пустыми.");
            }

            if (_termsDict.ContainsKey(name)) {
                throw new InvalidOperationException("Термин уже существует.");
            }

            _termsDict.Add(name, definition);
        }

        /// <summary>
        /// Updates definition of the term.
        /// </summary>
        /// <param name="name">Name of the term, definition of which must be updated.</param>
        /// <param name="definition">New definition.</param>
        public void Update(string name, string definition) {
            if (_termsDict[name] == definition) {
                return;
            }

            _termsDict[name] = definition;
        }

        /// <summary>
        /// Finds term by it's name.
        /// </summary>
        /// <param name="name">Name of the term to find.</param>
        /// <returns>Returns definition of the term.</returns>
        /// <exception cref="KeyNotFoundException">Throws KeyNotFoundException if term doesn't exist.</exception>
        public string Find(string name) {
            if (!_termsDict.ContainsKey(name)) {
                throw new KeyNotFoundException("Термина не существует.");
            }

            return _termsDict[name];
        }

        /// <summary>
        /// Removes term from the dictionary.
        /// </summary>
        /// <param name="name">Name of the term to remove.</param>
        /// <returns>Returns true if operation is successfull, otherwise - false.</returns>
        public bool Remove(string name) {
            if (!_termsDict.ContainsKey(name)) {
                return false;
            }

            _termsDict.Remove(name);
            return true;
        }

        /// <summary>
        /// Gets all terms from the dictionary.
        /// </summary>
        /// <returns>Returns list of key-value pairs.</returns>
        public List<KeyValuePair<string, string>> GetAllTerms() { 

            return _termsDict.ToList();
        }

        /// <summary>
        /// Counts all terms in the dictionary.
        /// </summary>
        /// <returns>Returns number of terms in the dictionary.</returns>
        public int Count() {
            return _termsDict.Count;
        }
    }
}
