using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArriendoDeAutosASP.Data;
using ArriendoDeAutosASP.Models;
using ArriendoDeAutosASP.Controllers;
using FluentEmail.Smtp;
using System.Net;
using FluentEmail.Core;

namespace ArriendoDeAutosASP.Controllers
{
    public class EmailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Email.ToListAsync());
        }

        // GET: Emails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email
                .FirstOrDefaultAsync(m => m.Id == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: Emails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmailFrom,EmailTo,EmailSubject,EmailBody,DateTime")] ArriendoDeAutosASP.Models.Email email)
        {

            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Mailing", "Emails", email);
                await Mailing(email);
                return RedirectToAction("Details", "Emails", email);
                //return RedirectToAction(nameof(Mailing));
            }
            return View(email);
        }

        // GET: Emails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmailFrom,EmailTo,EmailSubject,EmailBody,DateTime")] ArriendoDeAutosASP.Models.Email email)
        {
            if (id != email.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(email);
        }

        // GET: Emails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email
                .FirstOrDefaultAsync(m => m.Id == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var email = await _context.Email.FindAsync(id);
            _context.Email.Remove(email);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailExists(int id)
        {
            return _context.Email.Any(e => e.Id == id);
        }

        public async Task <IActionResult> Mailing(ArriendoDeAutosASP.Models.Email email)
        {
            var sender = new SmtpSender(() => new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("", ""),
                EnableSsl = true,
            });
            FluentEmail.Core.Email.DefaultSender = sender;

            /*Importante: 
             * Las credenciales de sender son quienes permiten enviar el correo,
             * entonces, este correo siempre va desde Tay a Tay.
             * Lo importante es, que el destinatario real debe ingresar su correo para adjuntarlo al asunto,
             * y de esta forma se puede seguir la conversacion con el cliente.
             * Por ultimo, no dejare ninguna credencial ...
             */
            var emailHead = FluentEmail.Core.Email
                //.From(email.EmailTo, email.EmailFrom)
                .From(email.EmailFrom, email.EmailFrom)
                //.To(email.EmailFrom)
                .To(email.EmailTo)
                .Subject(email.EmailSubject)
                .Body(email.EmailBody + " / DateTime: " + email.DateTime);
            try
            {
                await emailHead.SendAsync();
            } catch (Exception e)
            {
                
            }

            return View();
        }
    }
}
