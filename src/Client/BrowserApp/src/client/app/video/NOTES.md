# Using Videogular2

> npm install videogular2
This added to package.json:
    "videogular2": "^4.0.0",
In app.module.ts, add
    import { VideoModule } from './video/video.module';
    ...
    imports: [ ... VideoModule, ... ]    
   
    
## Including Videogular2 in system-config.ts

https://github.com/videogular/videogular2/issues/175 suggests:

In system-config.ts, change:
    packages: {
    }
To:
    map:{
    'videogular2': 'videogular2',
    },
    packages: {
      'videogular2':{
            main: 'core.js',
            defaultExtension:'js'
      }
    }

[ NOTE: angular-seed uses SYSTEM_CONFIG_DEV in seed.config.ts to store system-config.ts settings.
  So the above changes were made there. ]


# Build Error - missing type definition for core-js

During "build.js.dev" there were the following errors:
    error TS2688: Cannot find type definition file for 'core-js'

https://github.com/videogular/videogular2/issues/355 suggests:

In the end I solved this for me with:
 npm install --save @types/core-js

In package.json:
"dependencies": {
   ...
    "@types/core-js": "^0.9.35"  _(my Visual Studio stated: no version available)_
    ...
    "videogular2": "4.0.0",
   ...
   }

and in tsconfig.json
 "compilerOptions": {
    ...
    "target": "es5",
    "typeRoots": [
      "../node_modules/@types"
    ],
    "lib": [ "es5", "dom" ],
    ...
  },

[ Note: I tried the first step, "npm install --save @types/core-js". IO then got
 about 30 errors "Duplicate identifier", All declarations of xxxx must hae identical modifiers", etc.
 I needed to remove @types/core-js from package.json and delete its directory in node_modules. ]

 # Splitting a video

A downloaded mp4 file of a selectmen's meeting from YouTube worked fine with Videogular.
I tried to create a shortened version for a demo. "Any Video Converter" has a "clip" feature,
but it only clips during a "convert". I didn't want to convert. I only wanted to clip.
I found this tutorial for doing it: http://www.any-video-converter.com/support/tutorials/clip-video.php
It selects "Customized MP$ Movie" format as that to convert to. This worked, but the video
displayed much smaller than the original.

I used MediaInfo to see the encoding info about the files. 
The codecs used are the same:  video=AVC and audio=AAC.
But there are many differences, in bit rate, size, pixels/frame, etc.

I need to find a better program for splitting the file.
I tried using VLC. See: https://darktips.com/split-video-audio-file/
This did a much better job. It kept the data much closer:
    data        Original        Clipped
    bit rate    269             277
    aspect      16:9 (1.777)    1.739

"MKV Extractor" is a recommended tool for splitting.

# Converting a video

There are three main video formats for HTML5 video on the web: mp4, ogg & webm.
I was able to use VLC to convert the mp4 to ogg. But VLC crashed every time that
I tried to convert to WEBM.
I used: http://www.online-convert.com


