namespace SixtyNineDegrees.MiteDesk.Core.Infrastructure
{
    public interface IEncryptionService
    {
        string EncryptString(string clearText, string password);
        string DecryptString(string cipherText, string password);
    }
}
