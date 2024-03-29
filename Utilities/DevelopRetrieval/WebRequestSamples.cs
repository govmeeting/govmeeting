﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GM.Utilities.DevelopRetrieval
{
    class WebRequestSamples
    {

        public void PrintHeaders(string url)
        {
            // Create a 'WebRequest' object with the specified url. 	
            WebRequest myWebRequest = WebRequest.Create(url);

            // Send the 'WebRequest' and wait for response.
            WebResponse myWebResponse = myWebRequest.GetResponse();

            // Display all the Headers present in the response received from the URl.
            Console.WriteLine("\nThe following headers were received in the response");

            // Display each header and it's key , associated with the response object.
            for (int i = 0; i < myWebResponse.Headers.Count; ++i)
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", myWebResponse.Headers.Keys[i], myWebResponse.Headers[i]);

            // Release resources of response object.
            myWebResponse.Close();
        }




    }
}
