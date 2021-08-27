using UnityEngine;
using System.Collections;
using System.Text;
// Required for all examples
using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

using Amazon;
using Amazon.CognitoIdentity;
using Amazon.Runtime;
// Required for the GetS3BucketsAsync example
using Amazon.S3;
using Amazon.S3.Model;
public class UploadS3 : MonoBehaviour
{
    [SerializeField] private string _bucketName = "hamatest";

    CognitoAWSCredentials _credentials;

    private void Awake()
    {
        _credentials = new CognitoAWSCredentials (
            "ap-northeast-1:532110d6-f83b-4752-a1a8-698590fbdeb2", // Identity pool ID
            RegionEndpoint.APNortheast1 // Region
        );
    }
    
    public async void upload(){
        AmazonS3Client client = new AmazonS3Client(_credentials, RegionEndpoint.GetBySystemName(RegionEndpoint.APNortheast1.SystemName));
        String filename = "test";

        FileStream stream = new FileStream(Application.dataPath + "/CameraView.png", FileMode.Open, FileAccess.Read, FileShare.Read);

        var request = new UploadPartRequest
        {
            BucketName = _bucketName,
            Key = filename,
            InputStream = stream,
        };

        UploadPartResponse result = await client.UploadPartAsync(request);

        Debug.Log(result);

        stream.Close();

    }
    
}
