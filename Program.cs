using System.Security.Cryptography.X509Certificates;
using System;
using GoogleDriveTools;

namespace GoogleDrive201405
{
    class Program
    {
    //    private static String ACTIVITY_ID = "z12gtjhq3qn2xxl2o224exwiqruvtda0i";
        public static void Main(string[] args)
        {
            GoogleDriveFileUploader up = new GoogleDriveFileUploader();
        //    up.UploadFileFromServiceAccount();
            up.UploadFileInParticularFolder()
            ;
        }
    }
}
