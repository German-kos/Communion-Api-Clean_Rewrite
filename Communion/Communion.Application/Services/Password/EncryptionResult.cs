namespace Communion.Application.Services.Password;

public record EncryptionResult(
    byte[] hash,
    byte[] key);