The library is for auto pre-processing recordings of meetings.
This includes code to:
* Monitor a location on the web for new recordings.
* Download the recording to Govmeeting.org.
* Split the recording into smaller segments which will be then auto transcribed.
* Auto-transcribe the segments of the recording using the Google Speech API.
* Re-merge the transcript segments.
* Convert the transcript into a JSON object which will be the input for further volunteer processing.


https://cloud.google.com/speech/docs/encoding

One of the most popular digital audio techniques (popularized in use of the Compact Disc) is known as Pulse Code Modulation (or PCM).
Audio is sampled at set intervals, and the amplitude of the sampled wave at that point is stored as a digital value using the 
sample's bit depth.

Linear PCM (which indicates that the amplitude response is linearly uniform across the sample) is the
standard used within CDs, and within the Speech API's LINEAR16 encoding. 

Reading a one-channel stream of bytes encoded using Linear PCM, you could count off every 16 bits (2 bytes),
for example, to get another amplitude value of the waveform. Almost all devices can manipulate such digital data natively —
you can even crop Linear PCM audio files using a text editor — but (obviously) uncompressed audio is not the most efficient
way to transport or store digital audio. For that reason, most audio uses digital compressions techniques.

The Speech API supports two lossless encodings: FLAC and LINEAR16. Technically, LINEAR16 isn't "lossless compression" 
because no compression is involved in the first place. If file size or data transmission is important to you, 
choose FLAC as your audio encoding choice.

Although the Speech API supports several lossy formats, you should avoid them if you have control over the source audio. 
Although the removal of such data through lossy compression may not noticably affect audio as heard by the human ear,
loss of such data to a speech recognition engine may significantly degrade accuracy.

