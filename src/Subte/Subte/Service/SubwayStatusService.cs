using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Xamarin.Forms.Dependency(typeof(Subte.SubwayStatusService))]
namespace Subte
{
    class SubwayStatusService : ISubwayStatusService
    {
        public async Task<IEnumerable<SubwayLine>> GetStatusAsync()
        {
            var URL = "http://www.metrovias.com.ar/Subterraneos/Estado?site=Metrovias";

            var req = WebRequest.CreateHttp(URL);
            var resp = await req.GetResponseAsync();
            var json = string.Empty;

            using (var sr = new StreamReader(resp.GetResponseStream()))
                json = await sr.ReadToEndAsync();

            var result = new List<SubwayLine>();
            var lines = JsonConvert.DeserializeObject<Line[]>(json);
            foreach (var line in lines.Where(l => !l.LineName.Equals("U", StringComparison.OrdinalIgnoreCase)))
            {
                result.Add(new SubwayLine
                {
                    Name = line.LineName,
                    Status = line.LineStatus.Equals("Normal", StringComparison.OrdinalIgnoreCase) ? "Normal" : $"Con problemas: {line.LineStatus}",
                    ImageSource = GetImageSource(line.LineName)
                });
            }

            return result;
        }

        ImageSource GetImageSource(string lineName)
        {
            try
            {
                //TODO: test what happens if the image doesn't exist
                return ImageSource.FromFile($"Image/line{lineName.ToUpper()}.png");
            }
            catch (Exception)
            {
                return ImageSource.FromFile($"Image/noImage.png");
            }
        }
    }

    class Line
    {
        public string LineName { get; set; }
        public string LineStatus { get; set; }
        public string LineFrequency { get; set; }
    }
}
