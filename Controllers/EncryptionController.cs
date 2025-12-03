using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRYPTOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        // ⭐ Hello endpoint for browser testing
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("API is running!");
        }

        // ⭐ Simple Caesar cipher (+3)
        private string EncryptText(string input)
        {
            return new string(input.Select(c => (char)(c + 3)).ToArray());
        }

        private string DecryptText(string input)
        {
            return new string(input.Select(c => (char)(c - 3)).ToArray());
        }

        // ⭐ POST /Encryption/encrypt
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string text)
        {
            var encrypted = EncryptText(text);
            return Ok(encrypted);
        }

        // ⭐ POST /Encryption/decrypt
        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string text)
        {
            var decrypted = DecryptText(text);
            return Ok(decrypted);
        }
    }
}
