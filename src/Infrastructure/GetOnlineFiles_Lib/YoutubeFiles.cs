using System;
using System.Collections.Generic;
using System.Text;

namespace GM.GetOnlineFiles
{
    class YoutubeFiles
    {
    }
}

/*  Layout of ayoutube subscription page
 *  
 *  Sample source for the Little Falls subscription page is in:
 *  Utilities\DevelopTranscription\youtube_channel_2010-12-09.html
 *  
 *  Here is a section related to a meeting:
 
    title: {
        accessibility: {
        accessibilityData: {
            label:
            "Little Falls, NJ December 7, 2020 Township Council VIRTUAL Workshop Meeting by Little Falls, NJ Township Streamed 1 day ago 1 hour, 8 minutes 33 views",
        },
        },
        simpleText:
        "Little Falls, NJ December 7, 2020 Township Council VIRTUAL Workshop Meeting",
    },
    publishedTimeText: {
        simpleText: "Streamed 1 day ago",
    },
    viewCountText: {
        simpleText: "33 views",
    },
    navigationEndpoint: {
        clickTrackingParams:
        "CEwQlDUYASITCInhrtSTwe0CFUvfYAodPAID1jIKZy1oaWdoLWNydloYVUNuWG1aZlhJeEI5bl9iNlBNb2gwa21BmgEFEPI4GGY=",
        commandMetadata: {
        webCommandMetadata: {
            url: "/watch?v=uBJnl0d0jEY",
            webPageType:
            "WEB_PAGE_TYPE_WATCH",
            rootVe: 3832,
        },
        },
        watchEndpoint: {
        videoId: "uBJnl0d0jEY",
        },
    },

 *  These are the important lines:
   
    label:
    "Little Falls, NJ December 7, 2020 Township Council VIRTUAL Workshop Meeting by Little Falls, NJ Township Streamed 1 day ago 1 hour, 8 minutes 33 views",
    ...
    videoId: "uBJnl0d0jEY",

* From this we can extract:
 
   title:      Little Falls, NJ December 7, 2020 Township Council VIRTUAL Workshop Meeting
   uploader:   Little Falls, NJ Township
   streamed:   1 day ago
   length:     1 hour, 8 minutes
   views:      33 views
   videoId:    uBJnl0d0jEY         - this is used for downloading
*/
