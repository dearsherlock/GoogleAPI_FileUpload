using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleDriveTools
{
    public class GoogleDriveFileUploader
    {
        public void ListFiles() {
            UserCredential credential
             ;
            try
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
             new ClientSecrets
             {
                 ClientId = "XXXX.apps.googleusercontent.com",
                 ClientSecret = "XXXX",
             },
             new[] { DriveService.Scope.Drive },
             "user",
             CancellationToken.None).Result;
            }
            catch (Exception e)
            {

                throw e;
            }

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample2",
            });
            var files = service.Files.List().Execute();
            foreach (var fileI in files.Items)
            {
                string title = fileI.Title;
            }

        
        }
        public void UploadFileInParticularFolder()
        {


            UserCredential credential
                ;
            try
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
             new ClientSecrets
             {
                 ClientId = "XXXX.apps.googleusercontent.com",
                 ClientSecret = "XXXXX",
             },
             new[] { DriveService.Scope.Drive },
             "user",
             CancellationToken.None).Result;
            }
            catch (Exception e)
            {

                throw e;
            }

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample2",
            });

            File body = new File();
            body.Title = "My document_"+DateTime.Now;
            body.Description = "A test document";
            body.MimeType = "text/plain";
            //Assign Parent Id
            body.Parents = new List<ParentReference>() { new ParentReference() { Id = "0B62x5TTVLXXXXXXXXX" } };
            byte[] byteArray = System.IO.File.ReadAllBytes("document.txt");
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
          
            FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");
            request.Upload();

        }
       
        public string UploadFile() {
           

            UserCredential credential
                ;
            try
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
             new ClientSecrets
             {
                 ClientId = "XXXX.apps.googleusercontent.com",
                 ClientSecret = "XXXXX",
             },
             new[] { DriveService.Scope.Drive },
             "user", 
             CancellationToken.None).Result;
            }
            catch (Exception e)
            {

                throw e;
            }
            
            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample2",
            });

            File body = new File();
            body.Title = "My document2";
            body.Description = "A test document";
            body.MimeType = "text/plain";

            byte[] byteArray = System.IO.File.ReadAllBytes("document.txt");
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

            FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");
            request.Upload();

            File file = request.ResponseBody;
            
            //Console.WriteLine("File id: " + file.Id);
            //Console.WriteLine("Press Enter to end this process.");
            //Console.ReadLine();
            return file.Id;
        }
        public string UploadFileFromServiceAccount()
        {

            ServiceAccountCredential credential;
            String serviceAccountEmail = "XXXXXX@developer.gserviceaccount.com";
            try
            {
                var certificate = new X509Certificate2("76754c4d00cddbe26d3caa9e567a3d39ba6833cb-privatekey.p12", "notasecret", X509KeyStorageFlags.Exportable);
                 credential = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    Scopes = new[] { DriveService.Scope.Drive }
                }.FromCertificate(certificate));
                
            }
            catch (Exception e)
            {

                throw e;
            }


            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API",
            });

            #region MyRegion
            Google.Apis.Drive.v2.Data.File folder = new Google.Apis.Drive.v2.Data.File();
folder.Title = "My first folder";
folder.Description = "folder document description";
folder.MimeType = "application/vnd.google-apps.folder";

// service is an authorized Drive API service instance
Google.Apis.Drive.v2.Data.File fileFolder = service.Files.Insert(folder).Execute();

            #endregion



 var files= service.Files.List().Execute();
            foreach(var fileI in files.Items)
            {
               string title= fileI.Title;
            }



            File body = new File();
            body.Title = "My document2";
            body.Description = "A test document";
            body.MimeType = "text/plain";

            byte[] byteArray = System.IO.File.ReadAllBytes("document.txt");
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

            FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");
            request.Upload();

            File file = request.ResponseBody;
         //   var file1=service.Files.Get("0B3cUo6GBC0YvaGVPSUF5TG1CZzg").Execute();
          //  var file2 = service.Files.Get("0B3cUo6GBC0YvemhMYURNVmZYRUk").Execute();
            //Console.WriteLine("File id: " + file.Id);
            //Console.WriteLine("Press Enter to end this process.");
            //Console.ReadLine();
            return file.Id;
        } 
  
    }
}
