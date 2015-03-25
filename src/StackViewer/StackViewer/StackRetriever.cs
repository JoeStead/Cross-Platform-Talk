using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;

namespace StackViewer
{
    class StackRetriever
    {
        private const string API_BASE = "https://api.stackexchange.com/2.2/"; //Could be better in a resource file?

        private static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate");
            return client;
        }

        private static async Task<string> ParseResult(byte[] data)
        {
            using (var outStream = new MemoryStream(data))
            {
                using (var zipStream = new GZipStream(outStream, CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(zipStream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }

        public async Task<string> GetQuestions()
        {
            using (var client = CreateClient())
            {
                var result = await client.GetByteArrayAsync(string.Format("{0}search?order=desc&sort=votes&tagged=c%23&site=stackoverflow", API_BASE));

                return await ParseResult(result);
            }
        }

        public async Task<string> GetAnswers(int questionId)
        {
            using (var client = CreateClient())
            {
                var result = await client.GetByteArrayAsync(string.Format("{0}/questions/{1}/answers?order=desc&sort=votes&site=stackoverflow", API_BASE, questionId));

                return await ParseResult(result);
            }
        }

    }
}
