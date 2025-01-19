
namespace App.Application.Features.ErrorLogFeatures.Create;

public sealed record CreateErrorLogCommand(string ErrorMessage,
string? StackTrace,
string RequestPath,
string RequestMethod,
DateTime Timestamp);

