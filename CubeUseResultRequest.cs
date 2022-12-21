using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MaplestoryOpenAPI
{
    public class CubeUseResultRequest
    {
        private StringBuilder builder;

        public CubeUseResultRequest()
        {
            builder = new StringBuilder();
        }

        public CubeHistoryResponseDTO GetDataByDate(string apiKey, int resultPerPage, int year, int month, int day)
        {
            string url = m_GetUrlByDate(resultPerPage, year, month, day);
            return m_RequestData(apiKey, url);
        }

        public CubeHistoryResponseDTO GetDataByCursor(string apiKey, int resultPerPage, string cursor)
        {
            string url = m_GetUrlByCursor(resultPerPage, cursor);
            return m_RequestData(apiKey, url);
        }

        private string m_GetUrlByDate(int resultPerPage, int year, int month, int day)
        {
            builder.Clear();
            builder.Append("https://public.api.nexon.com/openapi/maplestory/v1/cube-use-results?");
            builder.AppendFormat("count={0}", resultPerPage);
            builder.AppendFormat("&date={0,4:D4}-{1,2:D2}-{2,2:D2}", year, month, day);
            builder.Append("&cursor=");
            return builder.ToString();
        }

        private string m_GetUrlByCursor(int resultPerPage, string cursor)
        {
            builder.Clear();
            builder.Append("https://public.api.nexon.com/openapi/maplestory/v1/cube-use-results?");
            builder.AppendFormat("count={0}", resultPerPage);
            builder.Append("&date=");
            builder.AppendFormat("&cursor={0}", cursor);
            return builder.ToString();
        }

        private CubeHistoryResponseDTO m_RequestData(string apiKey, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", apiKey);

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = response.StatusCode;

                using(Stream responseStream = response.GetResponseStream())
                using(StreamReader reader = new StreamReader(responseStream))
                {
                    string strData = reader.ReadToEnd();
                    return JsonSerializer.Deserialize<CubeHistoryResponseDTO>(strData);
                }
            }
        }
    }
}
