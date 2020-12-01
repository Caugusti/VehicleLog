using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicle_Log_MVC;

// Essa classe representa o sistema de controle do modelo Vehicle Types.
// Nela será possível controlar os comandos de interação com a interface da View. 
// Além de armazenar e manipular os dados que serão inseridos no banco de dados Vehicle Types.

namespace Vehicle_Log_MVC.Controllers
{
    public class VehicleTypesController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: VehicleTypes
        // Este método irá abrir a interface Index, onde será possível visualizar os tipos de veículos que  
        // estão armazenados no banco de dados, através do formato de lista.
        public ActionResult Index()
        {
            return View(db.VehicleType.ToList());
        }

        // GET: VehicleTypes/Details/5
        // Este método irá abrir a interface de detalhes referente ao item escolhido na interface Index.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = db.VehicleType.Find(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // GET: VehicleTypes/Create
        // Este método irá abrir a interface de adição de novos tipos de veículos, para, posteriormente, serem
        // utilizá-los para compor os elementos de um veículo.
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        // Este método irá salvar os dados preenchidos na interface em seu banco de dados (VehicleTypes).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Family,Vehicle,VehicleType1")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                db.VehicleType.Add(vehicleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleType);
        }

        // GET: VehicleTypes/Edit/5
        // Este método irá abrir a interface para edição do item selecionado na interface Index.
        // Ele irá buscar em seu banco de dados, os dados referentes ao item e inseri-los nos campos de edição.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = db.VehicleType.Find(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // POST: VehicleTypes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        // Este método irá efetuar a ação de salvar os novos dados do item selecionado.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Family,Vehicle,VehicleType1")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleType);
        }

        // GET: VehicleTypes/Delete/5
        // Este método irá apresentar a tela com os detalhes do item selecionado na interface Index,
        // para que se verifique os dados antes de deletá-los.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = db.VehicleType.Find(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // POST: VehicleTypes/Delete/5
        // Este método irá executar a ação de deletar os dados do item selecionado.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleType vehicleType = db.VehicleType.Find(id);
            db.VehicleType.Remove(vehicleType);
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
