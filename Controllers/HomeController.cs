using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites;
using PartyInvites.Models;
using System.Linq;
using System.Collections.Generic;

namespace Partylnvites.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            
            return View("RsvpForm");
        }
        
        [HttpPost]
        public ViewResult ListResponses(int LabelStudentsNumber,string comboBoxValue,List<int> messagesLimit)
        {
            Repository.ClearAll();
            Repository.StudentsNum = LabelStudentsNumber.ToString();
            Repository.Event = comboBoxValue;
            if (LabelStudentsNumber==messagesLimit.Count)
            {
                Repository.AddResponse(messagesLimit);
                Repository.startAlgorithm(messagesLimit);
            }
            else
            {
                Repository.History = "Вы не заполнили все поля c количеством сообщений";
                Repository.Succes = false;
            }
            return View("ListResponses");
        }

    }
}




