using Microsoft.AspNetCore.Http;

namespace OlympicGames.Infrastructure.Settings
{
    public class CreateItemVM
    {
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
