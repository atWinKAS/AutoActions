﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ActionsServer.Models;

namespace ActionsServer.Controllers
{
    public class LettersController : ApiController
    {
        private ActionsServerContext db = new ActionsServerContext();

        // GET: api/Letters 
        public IQueryable<Letter> GetLetters()
        {
            return db.Letters;
        }

        // GET: api/Letters/5
        [ResponseType(typeof(Letter))]
        public IHttpActionResult GetLetter(int id)
        {
            Letter letter = db.Letters.Find(id);
            if (letter == null)
            {
                return NotFound();
            }

            return Ok(letter);
        }

        // PUT: api/Letters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLetter(int id, Letter letter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != letter.Id)
            {
                return BadRequest();
            }

            db.Entry(letter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LetterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Letters
        [ResponseType(typeof(Letter))]
        public IHttpActionResult PostLetter(Letter letter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Letters.Add(letter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = letter.Id }, letter);
        }

        // DELETE: api/Letters/5
        [ResponseType(typeof(Letter))]
        public IHttpActionResult DeleteLetter(int id)
        {
            Letter letter = db.Letters.Find(id);
            if (letter == null)
            {
                return NotFound();
            }

            db.Letters.Remove(letter);
            db.SaveChanges();

            return Ok(letter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LetterExists(int id)
        {
            return db.Letters.Count(e => e.Id == id) > 0;
        }
    }
}