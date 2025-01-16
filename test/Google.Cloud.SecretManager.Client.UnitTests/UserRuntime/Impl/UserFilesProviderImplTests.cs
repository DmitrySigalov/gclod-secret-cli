using System.Runtime.InteropServices;
using Xunit;

namespace Google.Cloud.SecretManager.Client.UserRuntime.Impl;

public class UserFilesProviderImplTests
{
    [Fact]
    public void GetFullFilePath_IsOSXPlatform_WithToolUser()
    {
        var folderType = FolderTypeEnum.ToolUser;
        var fileName = "test.txt";

        var testComponent = new UserFilesProviderImpl();
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            var expectedFullPath = Path.Combine(
                Path.GetFullPath($"/Users/{Environment.UserName}"),
                ".gcloud-secrets-cli",
                fileName);

            var result = testComponent.GetFullFilePath(fileName, folderType);
            
            Assert.Equal(expectedFullPath, result);
        }
    }
    
    [Fact]
    public void GetFullFilePath_IsOSXPlatform_WithRootUser()
    {
        var folderType = FolderTypeEnum.RootUser;
        var fileName = "test.txt";

        var testComponent = new UserFilesProviderImpl();
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            var expectedFullPath = Path.Combine(
                Path.GetFullPath($"/Users/{Environment.UserName}"),
                fileName);

            var result = testComponent.GetFullFilePath(fileName, folderType);
            
            Assert.Equal(expectedFullPath, result);
        }
    }
}