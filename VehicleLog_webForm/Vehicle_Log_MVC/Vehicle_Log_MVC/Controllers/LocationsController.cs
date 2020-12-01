using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicle_Log_MVC;

// Essa classe representa o sistema de controle do modelo Locations.
// Nela será possível controlar os comandos de interação com a interface da View. 
// Além de armazenar e manipular os dados que serão inseridos no banco de dados Locations.

namespace Vehicle_Log_MVC.Controllers
{
    public class LocationsController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: Locations
        // Este método irá abrir a interface Index, onde será possível visualizar os locais que  
        // estão armazenados no banco de dados, através do formato de lista.
        public ActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        // GET: Locations/Details/5
        // Este método irá abrir a interface de detalhes referente ao item escolhido na interface Index.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return HttpNotFound();
            }
            return View(locations);
        }

        // GET: Locations/Create
        // Este método irá abrir a interface de adição de novos localizações, para, posteriormente, serem
        // utilizá-los para compor os elementos de um veículo.
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        // Este método irá salvar os dados preenchidos na interface em seu banco de dados (Locations).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ford_Locations,State")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(locations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locations);
        }

        // GET: Locations/Edit/5
        // Este método irá abrir a interface para edição do item selecionado na interface Index.
        // Ele irá buscar em seu banco de dados, os dados referentes ao item e inseri-los nos campos de edição.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return HttpNotFound();
            }
            return View(locations);
        }

        // POST: Locations/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        // Este método irá efetuar a ação de salvar os novos dados do item selecionado.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ford_Locations,State")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locations);
        }

        // GET: Locations/Delete/5
        // Este método irá apresentar a tela com os detalhes do item selecionado na interface Index,
        // para que se verifique os dados antes de deletá-los.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations locations = db.Locations.Find(id);
            if (locations == null)
            {
                return HttpNotFound();
            }
            return View(locations);
        }

        // POST: Locations/Delete/5
        // Este método irá executar a ação de deletar os dados do item selecionado.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locations locations = db.Locations.Find(id);
            db.Locations.Remove(locations);
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
