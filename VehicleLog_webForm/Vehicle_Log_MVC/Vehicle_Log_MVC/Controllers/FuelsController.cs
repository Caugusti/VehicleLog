using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicle_Log_MVC;

// Essa classe representa o sistema de controle do modelo Fuel.
// Nela será possível controlar os comandos de interação com a interface da View. 
// Além de armazenar e manipular os dados que serão inseridos no banco de dados Fuel.

namespace Vehicle_Log_MVC.Controllers
{
    public class FuelsController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: Fuels
        // Este método irá abrir a interface Index, onde será possível visualizar os combustíveis que  
        // estão armazenados no banco de dados, através do formato de lista.
        public ActionResult Index()
        {
            return View(db.Fuel.ToList());
        }

        // GET: Fuels/Details/5
        // Este método irá abrir a interface de detalhes referente ao item escolhido na interface Index.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = db.Fuel.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // GET: Fuels/Create
        // Este método irá abrir a interface de adição de novos tipos de combustíveis, para, posteriormente, serem
        // utilizá-los para compor os elementos de um veículo.
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fuels/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        // Este método irá salvar os dados preenchidos na interface em seu banco de dados (Fuel).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fuel_Type,Fuel1,Density,Nationality")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                db.Fuel.Add(fuel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuel);
        }

        // GET: Fuels/Edit/5
        // Este método irá abrir a interface para edição do item selecionado na interface Index.
        // Ele irá buscar em seu banco de dados, os dados referentes ao item e inseri-los nos campos de edição.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = db.Fuel.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        // Este método irá efetuar a ação de salvar os novos dados do item selecionado.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fuel_Type,Fuel1,Density,Nationality")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuel);
        }

        // GET: Fuels/Delete/5
        // Este método irá apresentar a tela com os detalhes do item selecionado na interface Index,
        // para que se verifique os dados antes de deletá-los.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = db.Fuel.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Delete/5
        // Este método irá executar a ação de deletar os dados do item selecionado.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fuel fuel = db.Fuel.Find(id);
            db.Fuel.Remove(fuel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
