using System.Media;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Translator;

public static class VoiceVoxUtility
{
    //TODO: future goal run a voicevox container url and get this to work

    // IDK what to do need a voicevox running url
    const string baseUrl = "https://major-sites-follow.loca.lt/";
    private static readonly HttpClient httpClient = new HttpClient();

    public static async Task Speak(string text, int speakerId)
    {
        string query = await CreateAudioQuery(text, speakerId);


        using var request = new HttpRequestMessage(new HttpMethod("POST"), $"{baseUrl}synthesis?speaker={speakerId}&enable_interrogative_upspeak=true");
        request.Headers.TryAddWithoutValidation("accept", "audio/wav");

        request.Content = new StringContent(query);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        var response = await httpClient.SendAsync(request);

        // Will read a .wav audio file that contains the translated text but in japanese voice

        using var httpStream = await response.Content.ReadAsStreamAsync();
        var player = new SoundPlayer(httpStream);
        player.PlaySync();
    }

    public static async Task RecordSpeech(string outputWaveFilePath, string text, int speaker)
    {
        string query = await CreateAudioQuery(text, speaker);

        // Speaker id means the japanese speaker id from voicevox site each of them has their own id

        using var request = new HttpRequestMessage(new HttpMethod("POST"), $"{baseUrl}synthesis?speaker={speaker}&enable_interrogative_upspeak=true");
        request.Headers.TryAddWithoutValidation("accept", "audio/wav");

        request.Content = new StringContent(query);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        var response = await httpClient.SendAsync(request);

        using var fs = System.IO.File.Create(outputWaveFilePath);
        using var stream = await response.Content.ReadAsStreamAsync();
        stream.CopyTo(fs);
        fs.Flush();
    }

    private static async Task<string> CreateAudioQuery(string text, int speakerId)
    {
        // Mix all of them to create a .wav file
        using var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), $"{baseUrl}audio_query?text={text}&speaker={speakerId}");
        requestMessage.Headers.TryAddWithoutValidation("Bypass-Tunnel-Reminder", "true");
        requestMessage.Headers.TryAddWithoutValidation("accept", "application/json");

        requestMessage.Content = new StringContent("");
        requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
        var response = await httpClient.SendAsync(requestMessage);
        return await response.Content.ReadAsStringAsync();
    }
}