using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using OnlineBankingApp.Migrations;
using OnlineBankingApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineBanking.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankingContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(BankingContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                // The customer is already logged in, redirect to the home page

                return RedirectToAction("Home");
            }
            else
            {
                // The customer is not logged in, continue with the login process
                // ...
                return View();
            }
        }
        public IActionResult Home(Customer customer)
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                // The customer is already logged in, redirect to the home page
                return RedirectToAction("Index");
            }
            else
            {
                // The customer is not logged in, continue with the login process
                // ...
                Guid customerId = Guid.Parse(HttpContext.Session.GetString("CustomerId"));

                // Retrieve the customer details from the database
                var bal = _context.Customers
                .Include(c => c.Accounts)
                .ThenInclude(a => a.AccountActivities)
                .FirstOrDefault(c => c.CustomerId == customerId);
                var balance = bal.Accounts.FirstOrDefault()?.Balance ?? 0;
                ViewBag.Balance = balance.ToString("0.00");
                ViewBag.AccountNumber = bal.Accounts.FirstOrDefault()?.AccountNumber ?? 0;

                List<AccountActivity> Withdrawal = _context.AccountActivities
                    .Where(aa => aa.Account.CustomerId == customerId && aa.Amount > 0)
                    .OrderBy(aa => aa.ActivityDate)
                    .ToList();

                List<PaymentHistory> paymentHistory = _context.PaymentHistories
                                    .Where(ph => ph.CustomerId == customerId)
                                    .Select(ph => new PaymentHistory
                                    {
                                        Amount = ph.Amount,
                                        PaymentDate = ph.PaymentDate,
                                        Payee = new Payee
                                        {
                                            PayeeName = ph.Payee.PayeeName
                                        }
                                    })
                                    .OrderBy(ph => ph.PaymentDate)
                                    .ToList();
                List<object> combinedList = Withdrawal
                    .Select(w => new object[] { w.ActivityType, w.Amount, w.ActivityDate })
                    .Concat(paymentHistory
                        .Select(p => new object[] { "Payment", p.Amount, p.PaymentDate }))
                    .OrderByDescending(c => (DateTime)c[2])
                    .Cast<object>()
                    .Take(10)
                    .ToList();

                ViewBag.combinedList = combinedList;
                List<Customer> Customers = _context.Customers.ToList();
                ViewBag.Customers = Customers;
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Add the customer to the database

                _context.Customers.Add(customer);

                // Create a new account for the customer
                Account account = new Account();
                int maxAccountNumber = _context.Accounts.Max(a => (int?)a.AccountNumber) ?? 0;
                account.AccountNumber = maxAccountNumber == 0 ? 10000 : maxAccountNumber + 1;
                account.Balance = 0.0;
                account.CustomerId = customer.CustomerId;

                // Add the account to the database
                _context.Accounts.Add(account);

                _context.SaveChanges();
                // Store the new customer's ID and password in TempData
                TempData["NewCustomerId"] = customer.CustomerId;
                TempData["NewCustomerPassword"] = customer.Password;
                Console.WriteLine(customer.CustomerId);
                return RedirectToAction("Login");
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult Login()
        {
            //Console.WriteLine(TempData["NewCustomerId"] as string);
           
            return View();
        }
        [HttpPost]
        public IActionResult Login(Customer customer)
        {
           
            //var authenticatedCustomer = _context.Customers.SingleOrDefault(c => c.CustomerId == customer.CustomerId && c.Password == customer.Password);
            var authenticatedCustomer = _context.Customers
                .Include(c => c.Roles)
                .SingleOrDefault(c => c.CustomerId == customer.CustomerId && c.Password == customer.Password);
            if (authenticatedCustomer != null)
            {
                // Customer is authenticated, redirect to dashboard or account page
                // Set the authenticated customer ID in the session
                if (authenticatedCustomer.Status) {
                    TempData.Clear();
                    HttpContext.Session.SetString("CustomerId", authenticatedCustomer.CustomerId.ToString());
                    HttpContext.Session.SetString("Role", authenticatedCustomer.Roles.RoleName);
                    return RedirectToAction("Index");
                }
                else {
                    HttpContext.Session.Clear();
                    TempData["Message"] = "Your account is closed. Please contact the bank or visit the bank.";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                // Customer is not authenticated, show an error message
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View();
            }
        }
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
        public IActionResult Profile()
        {
            // Get the customer ID from the session
            Guid customerId = Guid.Parse(HttpContext.Session.GetString("CustomerId"));

            // Retrieve the customer details from the database
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return RedirectToAction("Index");
            }

            // Save the customer details as variables
            ViewBag.customerName = customer.CustomerName;
            ViewBag.tfn = customer.Tfn;
            ViewBag.address = customer.Address;
            ViewBag.city = customer.City;
            ViewBag.state = customer.State;
            ViewBag.postCode = customer.PostCode;
            ViewBag.phone = customer.Phone;

            // Pass the customer details as a model to the view
            return View();
        }


        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            Guid customerId = Guid.Parse(HttpContext.Session.GetString("CustomerId"));

            // Retrieve the customer details from the database
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.CustomerId == customerId);

            if (existingCustomer == null)
            {
                return NotFound();
            }

            // Update only the properties that are not null or empty
            if (!string.IsNullOrEmpty(customer.CustomerName))
            {
                existingCustomer.CustomerName = customer.CustomerName;
            }

            if (!string.IsNullOrEmpty(customer.Tfn))
            {
                existingCustomer.Tfn = customer.Tfn;
            }

            if (!string.IsNullOrEmpty(customer.Address))
            {
                existingCustomer.Address = customer.Address;
            }

            if (!string.IsNullOrEmpty(customer.City))
            {
                existingCustomer.City = customer.City;
            }

            if (!string.IsNullOrEmpty(customer.State))
            {
                existingCustomer.State = customer.State;
            }

            if (!string.IsNullOrEmpty(customer.PostCode))
            {
                existingCustomer.PostCode = customer.PostCode;
            }

            if (!string.IsNullOrEmpty(customer.Phone))
            {
                existingCustomer.Phone = customer.Phone;
            }

            if (!string.IsNullOrEmpty(customer.Password))
            {
                existingCustomer.Password = customer.Password;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Deposit()
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                // The customer is already logged in, redirect to the home page

                return RedirectToAction("Index");
            }
            else
            {
                // The customer is not logged in, continue with the login process
                Guid customerId = Guid.Parse(HttpContext.Session.GetString("CustomerId"));
                List<AccountActivity> AccountActivities = _context.AccountActivities
                    .Where(aa => aa.Account.CustomerId == customerId && aa.Amount > 0 && aa.ActivityType == "Deposit")
                    .OrderBy(aa => aa.ActivityDate)
                    .ToList();
                ViewBag.AccountActivities = AccountActivities;

                List<Customer> Customers = _context.Customers
                    .Where(aa => aa.Status == true && aa.RoleId == 2)
                    .ToList();
                ViewBag.Customers = new SelectList(Customers, "CustomerId", "CustomerName");

                List<AccountActivity> acti = _context.AccountActivities
                    .Where(aa => aa.Amount > 0 && aa.ActivityType == "Deposit")
                    .OrderBy(aa => aa.ActivityDate)
                    .Include(aa => aa.Account.Customer) // eager loading
                    .ToList();
                ViewBag.acti = acti;


                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDeposit(Guid CustomerId,[Bind("Balance")] Account account)
        {
            Guid customerId = CustomerId;

            // Retrieve the customer details from the database
            var bal = _context.Customers
                .Include(c => c.Accounts)
                .ThenInclude(a => a.AccountActivities)
                .FirstOrDefault(c => c.CustomerId == customerId);

            int accountId = bal.Accounts.FirstOrDefault()?.AccountId ?? 0;

            // Retrieve the account details from the database
            var existingAccount = _context.Accounts
                .Include(a => a.AccountActivities)
                .FirstOrDefault(a => a.AccountId == accountId);


            if (ModelState.IsValid)
            {
                // Update the account balance
                existingAccount.Balance += account.Balance;

                // Add a deposit activity to the account
                var activity = new AccountActivity
                {
                    ActivityDate = DateTime.Now,
                    Amount = account.Balance,
                    ActivityType = "Deposit"
                };

                existingAccount.AccountActivities.Add(activity);

                _context.SaveChanges();
            }

            return RedirectToAction("Deposit");
        }

        public IActionResult Withdrawal()
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                // The customer is already logged in, redirect to the home page

                return RedirectToAction("Index");
            }
            else
            {
                // The customer is not logged in, continue with the login process
                Guid customerId = Guid.Parse(HttpContext.Session.GetString("CustomerId"));
                List<AccountActivity> Withdrawal = _context.AccountActivities
                    .Where(aa => aa.Account.CustomerId == customerId && aa.Amount > 0 && aa.ActivityType == "Withdrawal")
                    .OrderBy(aa => aa.ActivityDate)
                    .ToList();

                List<Customer> Customers = _context.Customers
                    .Where(aa => aa.Status == true && aa.RoleId == 2)
                    .ToList();
                ViewBag.Customers = new SelectList(Customers, "CustomerId", "CustomerName");
                ViewBag.Withdrawal = Withdrawal;

                List<AccountActivity> acti = _context.AccountActivities
                    .Where(aa => aa.Amount > 0 && aa.ActivityType == "Withdrawal")
                    .OrderBy(aa => aa.ActivityDate)
                    .Include(aa => aa.Account.Customer) // eager loading
                    .ToList();
                ViewBag.acti = acti;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateWithdrawal(Guid CustomerId, [Bind("Balance")] Account account)
        {
            Guid customerId = CustomerId;

            // Retrieve the customer details from the database
            var bal = _context.Customers
                .Include(c => c.Accounts)
                .ThenInclude(a => a.AccountActivities)
                .FirstOrDefault(c => c.CustomerId == customerId);

            int accountId = bal.Accounts.FirstOrDefault()?.AccountId ?? 0;

            // Retrieve the account details from the database
            var existingAccount = _context.Accounts
                .Include(a => a.AccountActivities)
                .FirstOrDefault(a => a.AccountId == accountId);

            if (ModelState.IsValid && existingAccount.Balance >= account.Balance)
            {
                // Update the account balance
                existingAccount.Balance -= account.Balance;

                // Add a withdrawal activity to the account
                var activity = new AccountActivity
                {
                    ActivityDate = DateTime.Now,
                    Amount = account.Balance,
                    ActivityType = "Withdrawal"
                };

                existingAccount.AccountActivities.Add(activity);

                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Insufficient balance");
            }

            return RedirectToAction("Withdrawal");
        }
        public IActionResult PayBill()
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                // The customer is already logged in, redirect to the home page

                return RedirectToAction("Index");
            }
            else
            {
                // The customer is not logged in, continue with the login process
                Guid customerId = Guid.Parse(HttpContext.Session.GetString("CustomerId"));
                List<Payee> payees = _context.Payees.Where(p => p.CustomerId == customerId).ToList();
                ViewBag.Payees = new SelectList(payees, "PayeeId", "PayeeName");
                List<PaymentHistory> paymentHistory = _context.PaymentHistories
                    .Where(ph => ph.CustomerId == customerId)
                    .Select(ph => new PaymentHistory
                    {
                        Amount = ph.Amount,
                        PaymentDate = ph.PaymentDate,
                        Payee = new Payee
                        {
                            PayeeName = ph.Payee.PayeeName
                        }
                    })
                    .OrderBy(ph => ph.PaymentDate)
                    .ToList();
                ViewBag.PaymentHistory = paymentHistory;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay(int payeeId, double amount, Account account)
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                // The customer is not logged in, redirect to the login page

                return RedirectToAction("Login");
            }
            else
            {
                // The customer is logged in, continue with the payment process

                var customerId = Guid.Parse(HttpContext.Session.GetString("CustomerId"));
                // Retrieve the customer details from the database
                var bal = _context.Customers
                    .Include(c => c.Accounts)
                    .FirstOrDefault(c => c.CustomerId == customerId);

                double accountBal = bal.Accounts.FirstOrDefault()?.Balance ?? 0;

          

                var payee = await _context.Payees.FirstOrDefaultAsync(p => p.PayeeId == payeeId && p.CustomerId == customerId);

                if (payee == null)
                {
                    ModelState.AddModelError("", "Invalid payee.");
                }

                if (ModelState.IsValid && accountBal >= amount)
                {
                    foreach (string key in Request.Form.Keys)
                    {
                        if (key == "PayeeId")
                        {
                            var pay = Request.Form[key];
                            foreach (string x in pay)
                            {
                                accountBal -= amount;
                                var payment = new PaymentHistory
                                {
                                    Amount = amount,
                                    PaymentDate = DateTime.Now,
                                    PayeeId = int.Parse(x),
                                    CustomerId = customerId
                                };
                                var existingAccount = _context.Accounts.SingleOrDefault(c => c.CustomerId == customerId);

                                if (existingAccount == null)
                                {
                                    return NotFound();
                                }

                                // Update only the properties that are not null or empty
                                existingAccount.Balance = accountBal;

                                _context.PaymentHistories.Add(payment);
                                await _context.SaveChangesAsync();
                            }
                            
                        }
                    }
                    

                    return RedirectToAction("Home");
                }
                else
                {
                    return View();
                }
            }
        }
        public IActionResult UpdatePayees()
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                // The customer is already logged in, redirect to the home page

                return RedirectToAction("Login");
            }
            else
            {
                // The customer is not logged in, continue with the login process

                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePayees(Payee payee)
        {
            if (ModelState.IsValid)
            {
                Guid customerId = Guid.Parse(HttpContext.Session.GetString("CustomerId"));

                payee.CustomerId = customerId;
                _context.Payees.Add(payee);
                _context.SaveChanges();

            }

            return RedirectToAction("PayBill");
        }
        public IActionResult Closed(Guid id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            if (customer.RoleId == 1 || customer.RoleId == 3) // Prevent manager accounts from being closed
            {
                return Forbid();
            }

            if (customer.Status == true) // Account is currently open, so close it
            {
                customer.Status = false;
            }
            else // Account is currently closed, so reopen it
            {
                customer.Status = true;
            }

            _context.SaveChanges();
            return RedirectToAction("Home");

        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            if (customer.RoleId == 1 || customer.RoleId == 3) // Prevent manager accounts from being closed
            {
                return Forbid();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Home");
        }

    }
}
