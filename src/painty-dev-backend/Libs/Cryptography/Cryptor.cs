using Cryptography.Contracts;
using Cryptography.Models;

namespace Cryptography
{
    public class Cryptor
    {
        private ICryptorAlgorithm _cryptAlghoritm;
        public Cryptor(ICryptorAlgorithm alghoritm) =>
            _cryptAlghoritm = alghoritm;
        public ValidationModel Crypt(string word) =>
            _cryptAlghoritm.Crypt(word);
        public bool Validate(string word, ValidationModel model) =>
            _cryptAlghoritm.Validate(word, model);
    }
}
