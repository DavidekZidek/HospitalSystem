using Microsoft.AspNetCore.Http;

namespace HospitalSystem.Application.Abstraction;

public interface IFileUploadService
{
    string FileUpload(IFormFile fileToUpload, string folderNameOnServer);
}