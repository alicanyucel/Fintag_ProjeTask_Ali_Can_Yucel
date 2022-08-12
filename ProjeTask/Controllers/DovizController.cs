using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ProjeTask.Models;
using ProjeTask.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace ProjeTask.Controllers
{
    [Route("api/[controller]")]
    public class DovizController : Controller
    {
        private IRepository _repository;
        public DovizController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult DovizIslemler()
        {
            decimal sterlinal = 5;
            decimal sterlinsat = 2;
            decimal euroal = 5;
            decimal eurosat = 2;
            decimal dolarsat = 2;
            decimal dolaral = 5;
            string[] kurtipi = new string[3] { "USD", "EUR", "GBH" };
            var kurbilgileri = _repository.GetFiyatAll();
            var kullanicibilgileri = _repository.GetUsers();
            // Servisten gelen veriler

            // dolar için kurbilgileri[0] id=!25 alis 17.92 satis 17.99 tarih 12.08.2022
            // euro için servisten gelen veriler kurbilgileri[3] alis 18.51 satis 18.59 id=128
            //sterlin için gelen veriler kurbilgileri[4] alis=21.87 satis=22.03 id=129
            if (dolarsat <= kullanicibilgileri[0].Balance && kurtipi[0] == kurbilgileri[0].KurTipi)
            {
                kullanicibilgileri[0].Balance += dolarsat * kurbilgileri[0].Kursatis;
                return StatusCode(200, kullanicibilgileri[0].Balance);
                
            }
            if (dolaral <= kullanicibilgileri[0].Balance && kurtipi[0] == kurbilgileri[0].KurTipi)
            {
                kullanicibilgileri[0].Balance -= dolaral* kurbilgileri[0].KurAlis;
                return StatusCode(200, kullanicibilgileri[0].Balance);
            }
            if (euroal <= kullanicibilgileri[0].Balance && kurtipi[1] == kurbilgileri[3].KurTipi)
            {
                kullanicibilgileri[0].Balance -= euroal * kurbilgileri[3].KurAlis;
                return StatusCode(200, kullanicibilgileri[0].Balance);

            }
            if (eurosat <= kullanicibilgileri[0].Balance && kurtipi[2] == kurbilgileri[3].KurTipi)
            {
                kullanicibilgileri[0].Balance += eurosat * kurbilgileri[3].Kursatis;
                return StatusCode(200, kullanicibilgileri[0].Balance);
            }
            if (sterlinsat <= kullanicibilgileri[0].Balance && kurtipi[2] == kurbilgileri[4].KurTipi)
            {
                kullanicibilgileri[0].Balance += sterlinsat * kurbilgileri[4].Kursatis;
                return StatusCode(200, kullanicibilgileri[0].Balance);

            }
            if (sterlinal <= kullanicibilgileri[0].Balance && kurtipi[2] == kurbilgileri[4].KurTipi)
            {
                kullanicibilgileri[0].Balance -= sterlinal * kurbilgileri[4].KurAlis;
                return StatusCode(200, kullanicibilgileri[0].Balance);
            }

            return Ok();
        }
      
    }
}