using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftiusTest.Models
{
    public static class SendMessages
    {
        public static void Start(List<int> messagesLimit)
        {
            if (messagesLimit.Count - 1 > Sum(messagesLimit))
            {
                Repository.History = "Не получится оповестить всех студентов о новости";
                Repository.Succes = false;
                return;
            }
            if (messagesLimit.ElementAt(0).Equals(0))
            {
                Repository.History = "Первый элемент не должен быть равен нулю";
                Repository.Succes = false;
                return;
            }
            int i = 1;
            var dict = messagesLimit.ToDictionary(item => i++);
            Dictionary<int, int> res = new Dictionary<int, int>();
            if (dict.Count > 0)
            {
                res.Add(dict.ElementAt(0).Key, dict.ElementAt(0).Value);
            }
            foreach (var pair in dict.OrderBy(pair => pair.Value).Reverse())
            {
                if (pair.Key != 1)
                    res.Add(pair.Key, pair.Value);
            }

            int[] knew = new int[res.Count];
            int knewCount = 1;
            for (int j = 0; j < res.Count; j++)
            {
                var firstJ = res.ElementAt(j);
                if (firstJ.Value > 0 && j < res.Count)
                {
                    var nextJ = res.ElementAt(j + 1);
                    if (!isContained(nextJ.Key, knew))
                    {
                        res[firstJ.Key] = firstJ.Value - 1;
                        knew[0] = 1;
                        knew[knewCount] = nextJ.Key;
                        knewCount++;
                        Repository.History += $"Номер {firstJ.Key} сказал {nextJ.Key}-му;";
                        Repository.MessagesNum++;
                    }

                }

            }


            while (!isOver(knew))
            {
                for (int k = 0; k < res.Count; k++)
                {
                    if (res.ElementAt(k).Value > 0 && isContained(res.ElementAt(k).Key, knew))
                    {
                        for (int j = 0; j < res.Count; j++)
                        {
                            if (!isContained(res.ElementAt(j).Key, knew))
                            {
                                var backJ = res.ElementAt(k);
                                res[backJ.Key] = backJ.Value - 1;
                                knew[knewCount] = res.ElementAt(j).Key;
                                knewCount++;
                                Repository.History += $"Номер {backJ.Key} сказал {res.ElementAt(j).Key}-му;";
                                Repository.MessagesNum++;
                                break;
                            }
                        }
                    }
                }
            }

        }

        public static int Sum(List<int> mes)
        {
            int sum = 0;
            foreach (var m in mes)
            {
                sum += m;
            }
            return sum;
        }
        private static bool isContained(int key, int[] knew)
        {
            for (int i = 0; i < knew.Length; i++)
            {
                if (knew[i] == key)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isOver(int[] knew)
        {
            for (int i = 0; i < knew.Length; i++)
            {
                if (knew[i] < 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
