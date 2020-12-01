using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicle_Log_MVC;

// Essa classe representa o sistema de controle do modelo Active Vehicle.
// Nela será possível controlar os comandos de interação com a interface da View. 
// Além de armazenar e manipular os dados que serão inseridos no banco de dados ActiveVehicleDB.

namespace Vehicle_Log_MVC.Controllers
{
    public class ActiveVehicleDBsController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: ActiveVehicleDBs
        // Este método irá abrir a interface Index, onde será possível visualizar os veículos que estão armazenados no 
        // banco de dados, através do formato de lista.
        public ActionResult Index()
        {
            return View(db.ActiveVehicleDB.ToList());
        }

        // GET: ActiveVehicleDBs/Details/5
        // Este método irá abrir a interface de detalhes referente ao item escolhido na interface Index. 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveVehicleDB activeVehicleDB = db.ActiveVehicleDB.Find(id);
            if (activeVehicleDB == null)
            {
                return HttpNotFound();
            }
            return View(activeVehicleDB);
        }

        // GET: ActiveVehicleDBs/Create
        // Este método irá abrir a interface de criação de novos veículos, preenchendo os campos de dropdown
        // com os bancos de dados de Fuel, Ford Locations e Vehicle Type.
        public ActionResult Create()
        {
            var fuelList = db.Fuel.ToList();
            var locationsList = db.Locations.ToList();
            var vehicleTypeList = db.VehicleType.ToList();

            ViewBag.fuelList = fuelList;
            ViewBag.locationsList = locationsList;
            ViewBag.vehicleTypeList = vehicleTypeList;
            return View();
        }

        // POST: ActiveVehicleDBs/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        // Este método irá salvar os dados preenchidos na interface em seu banco de dados (ActiveVehicleDB).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Vehicle,RegistrationDate,VehicleType,Locations,VehicleModel,TAG,FuelType,ModelYear,Engine,Power,Weight,Color,Responsible,Comments,LastUpdate")] ActiveVehicleDB activeVehicleDB)
        {
            if (ModelState.IsValid)
            {
                activeVehicleDB.RegistrationDate = DateTime.Now;
                activeVehicleDB.LastUpdate = DateTime.Now;
                db.ActiveVehicleDB.Add(activeVehicleDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activeVehicleDB);
        }

        // GET: ActiveVehicleDBs/Edit/5
        // Este método irá abrir a interface para edição do véiculo selecionado na interface Index.
        // Irá buscar em seu banco de dados, os dados referentes ao veículo e inseri-los nos campos de edição.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveVehicleDB activeVehicleDB = db.ActiveVehicleDB.Find(id);

            ViewBag.fuelList = db.Fuel.ToList();
            ViewBag.locationsList = db.Locations.ToList();
            ViewBag.vehicleTypeList = db.VehicleType.ToList();

            if (activeVehicleDB == null)
            {
                return HttpNotFound();
            }
            return View(activeVehicleDB);
        }

        // POST: ActiveVehicleDBs/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.

        // Este método irá efetuar a ação de salvar os novos dados do veículo selecionado.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Vehicle,VehicleType,Locations,VehicleModel,TAG,FuelType,ModelYear,Engine,Power,Weight,Color,Responsible,Comments,LastUpdate")] ActiveVehicleDB activeVehicleDB)
        {
            if (ModelState.IsValid)
            {
                activeVehicleDB.RegistrationDate = DateTime.Now;
                activeVehicleDB.LastUpdate = DateTime.Now;
                db.Entry(activeVehicleDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activeVehicleDB);
        }

        // GET: ActiveVehicleDBs/Delete/5
        // Este método irá apresentar a tela com os detalhes do veículo selecionado na interface Index,
        // para que se verifique os dados antes de deletá-los.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveVehicleDB activeVehicleDB = db.ActiveVehicleDB.Find(id);
            if (activeVehicleDB == null)
            {
                return HttpNotFound();
            }
            return View(activeVehicleDB);
        }

        // POST: ActiveVehicleDBs/Delete/5
        // Este método irá executar a ação de deletar os dados do veículo selecionado.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActiveVehicleDB activeVehicleDB = db.ActiveVehicleDB.Find(id);
            db.ActiveVehicleDB.Remove(activeVehicleDB);
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
