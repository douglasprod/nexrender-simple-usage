using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using nexrender_tutorial;
using nexrender_tutorial.Models;

namespace nexrender
{
    public class Program
    {
        private static Random rnd = new Random();
        private static List<UserStatisticsDataModel> _userStatisticsData = new List<UserStatisticsDataModel>();
        private static List<NexrenderDataModel> _nexrenderDataModel = new List<NexrenderDataModel>();
        static void Main(string[] args)
        {
            GenerateData();
            PrepareData();
            RenderVideos();
        }

        static void PrepareData()
        {
            foreach (var user in _userStatisticsData)
            {
                _nexrenderDataModel.Add(new NexrenderDataModel
                {
                    template = new Template
                    {
                        src = @"file:///d:/nexrender-tutorial/Untitled Project.aep",
                        composition = "main"
                    },
                    assets = new List<Assets>
                    {
                        new Assets
                        {
                            type = "data",
                            layerName = "Username", 
                            property = "Source Text",
                            value = $"{user.Username}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "FavoriteTime",
                            property = "Source Text",
                            value = $"{user.FavoriteTime}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "FavoriteDay",
                            property = "Source Text",
                            value = $"{user.FavoriteDay}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "DeliveryTime",
                            property = "Source Text",
                            value = $"{user.DeliveryTime}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "FavoritePizza",
                            property = "Source Text",
                            value = $"{user.FavoritePizza}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "YearSum",
                            property = "Source Text",
                            value = $"{user.YearSum}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "MonthSum",
                            property = "Source Text",
                            value = $"{user.MonthSum}"
                        }
                    },
                    actions = new Actions()
                    {
                        postrender = new List<PostRender>
                        {
                            new PostRender
                            {
                                module = "@nexrender/action-encode",
                                preset = "mp4",
                                output = $"{user.Username}.mp4"
                            },
                            new PostRender
                            {
                                module = "@nexrender/action-copy",
                                input = $"{user.Username}.mp4",
                                output = $"D:/nexrender-tutorial/rendered/{user.Username}.mp4"
                            }
                        }
                    }
                });
            }
        }

        static void RenderVideos()
        {
            for (int video = 0; video < _nexrenderDataModel.Count; video++)
            {
                var task = Task.Run(() => StartNexrender(video));
                task.Wait();
            }
        }
        static void StartNexrender(int video)
        {
            string binary = "--binary=@\"C:/Program Files\\Adobe\\Adobe After Effects CC 2019\\Support Files\\aerender.exe\"";
            System.IO.File.WriteAllText(@"D:\\nexrender-tutorial\main.json", JsonConvert.SerializeObject(_nexrenderDataModel[video]));
            var proc = System.Diagnostics.Process.Start(
                @"D:\nexrender-tutorial\nexrender\nexrender-cli-win64.exe",
                $"--file D:/nexrender-tutorial/main.json {binary}");
            proc.WaitForExit();
        }
        static void GenerateData()
        {
            var countUsers = 5;
            for (int userId = 1; userId < countUsers + 1; userId++)
            {
                var yearSum = rnd.Next(512, 4813);
                _userStatisticsData.Add(new UserStatisticsDataModel
                {
                    DeliveryTime = $"{rnd.Next(10, 65)} min",
                    FavoriteDay = $"{Util._days[rnd.Next(0, Util._days.Count)]}",
                    FavoritePizza = $"{Util._pizzaNames[rnd.Next(0, Util._pizzaNames.Count)]}",
                    FavoriteTime = $"{rnd.Next(1, 23)}:00",
                    YearSum = $"{yearSum}",
                    MonthSum = $"{yearSum / 12}",
                    Username = $"user {userId}"

                });
            }
        }
    }
}