GoogleAPI_FileUpload
====================

Google Drive API File Upload

This is a project for upload file by Google Drive API。
I try to wrap data and logic of upload file to a particular directory.

The sample code of using the helper as below:


            GoogleDriveFileUploader up = new GoogleDriveFileUploader();
        //    up.UploadFileFromServiceAccount();
            up.UploadFileInParticularFolder()
            ;
        
