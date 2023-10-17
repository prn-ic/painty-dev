using Cryptography.Models;

namespace Cryptography.Contracts
{
    /// <summary>
    /// This interface is a contract for my custom encoding algorithms
    /// </summary>
    public interface ICryptorAlgorithm
    {
        /// <summary>
        /// This method encrypt the given word
        /// </summary>
        /// <param name="word">The word will be encoding</param>
        /// <returns><c>ValidationModel</c> (encrypted value)</returns>
        public ValidationModel Crypt(string word);
        /// <summary>
        /// This method validate the given word
        /// </summary>
        /// <param name="word">The word which will check</param>
        /// <param name="model">The rightly encrypted value</param>
        /// <returns>(bool) True, if word is correct, else return false</returns>
        public bool Validate(string word, ValidationModel model);
    }
}
