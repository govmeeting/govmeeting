using Google.Cloud.Translation.V2;

// This is in the process of being written.  

namespace GM.Utilities.TranslateText
{
    public class TranslateInCloud
    {
        // private AppSettings config;
        // private string GoogleCloudBucketName;
        TranslationClient translationClient;


        public TranslateInCloud(
             //AppSettings config
             //IOptions<AppSettings> _config
        )
        {
            //config = _config.Value;
            //GoogleCloudBucketName = config.GoogleCloudBucketName;
            translationClient = TranslationClient.Create();
        }

        public string TranslateTextFile (string path, string language)
        {
            string text = System.IO.File.ReadAllText(path);
            return TranslateText(text, language);
        }

        public string TranslateHtmlFile(string path, string language)
        {
            string text = System.IO.File.ReadAllText(path);
            return TranslateHtml(text, language);
        }

        public string TranslateText (string text, string language)
        {
            TranslationResult response = translationClient.TranslateText(text, language, LanguageCodes.English);
            //Console.WriteLine(response.TranslatedText);
            return response.TranslatedText;
        }

        public string TranslateHtml(string text, string language)
        {
            TranslationResult response = translationClient.TranslateHtml(text, language, LanguageCodes.English);
            //Console.WriteLine(response.TranslatedText);
            return response.TranslatedText;
        }

        public string DetectLanguage (string text)
        {
            var client = TranslationClient.Create();
            var text1 = "Selam Dünya!";
            var detection = translationClient.DetectLanguage(text1);
            //Console.WriteLine($"Language: {detection.Language}\tConfidence: {detection.Confidence}");
            return detection.Language;
        }

    }
}


