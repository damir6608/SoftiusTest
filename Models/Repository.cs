using SoftiusTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public static class Repository
    {
        public static string StudentsNum;
        public static string History;
        public static int MessagesNum;
        public static bool Succes = true;

        private static List<int> responses= new List<int>();
        public static IEnumerable<int> Responses
        {
            get { return responses; }
        }

        public static string Event { get; internal set; }

        public static void AddResponse(List<int> responce)
        {
            foreach (var r in responce)
            {
                responses.Add(r);
            }
        }
        public static void startAlgorithm(List<int> responce)
        {
            SendMessages.Start(responce);
        }
        public static void ClearAll()
        {
            Event = "";
            Succes = true;
            StudentsNum = "";
            MessagesNum = 0;
            History = "";
            responses.Clear();
        }
       
    }
}
