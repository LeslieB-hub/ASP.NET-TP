using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp1Mod5.Data;
using Tp1Mod5.Models;

namespace Tp1Mod5.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            List<Chat> listeChats = FakeDb.Instance.ListeChats;

            return View(listeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chatDetail = FakeDb.Instance.ListeChats.FirstOrDefault(x => x.Id == id);
            return View(chatDetail);
        }

        
        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            // A ne pas faire!!! Chat chatDelete = FakeDb.Instance.ListeChats[id];
            Chat chatDelete = FakeDb.Instance.ListeChats.FirstOrDefault(x => x.Id == id);
            return View(chatDelete);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Chat catDelete = FakeDb.Instance.ListeChats.FirstOrDefault(x => x.Id == id);
                FakeDb.Instance.ListeChats.Remove(catDelete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
