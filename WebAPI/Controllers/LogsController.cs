using Application.DTO.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class LogsController : ControllerBase
{
    private ILogger<LogsController> _logger;

    public LogsController(ILogger<LogsController> logger)
    {
        _logger = logger;
    }
    [HttpPost]
    public IActionResult Log(LogMessage msg)
    {
        switch (msg.Level)
        {
            case 0:
                _logger.Log(LogLevel.Trace, $"[ANG]: {msg.Message}");
                break;
            case 1:
                _logger.Log(LogLevel.Debug, $"[ANG]: {msg.Message}");
                break;
            case 2:
                _logger.Log(LogLevel.Information, $"[ANG]: {msg.Message}");
                break;
            case 3:
                _logger.Log(LogLevel.Information, $"[ANG]: {msg.Message}");
                break;
            case 4:
                _logger.Log(LogLevel.Warning, $"[ANG]: {msg.Message}");
                break;
            case 5:
                _logger.Log(LogLevel.Error, $"[ANG]: {msg.Message}");
                break;
            default:
                _logger.Log(LogLevel.None, $"[ANG]: {msg.Message}");
                break;
        }
        return Ok();
    }
}
