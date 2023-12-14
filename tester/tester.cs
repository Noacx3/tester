using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace tester
{
     class tester
    {

        static ExtentReports extent;
        static ExtentTest test;

        static void Main(string[] args)
        {

            extent = new ExtentReports();
            var reporte = new ExtentSparkReporter("C:\\Users\\18298\\Pictures\\Screenshots\\Informe.html");
            extent.AttachReporter(reporte);

            //iniciar el programa
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://localhost/Sistema-de-biblioteca-basico-php-8-y-mysql/");
            test = extent.CreateTest("Prueba Automatizada");
            test.Log(Status.Info, "Ingresado a la página de inicio");

            // Llenar el formulario de registro
            IWebElement input = driver.FindElement(By.Id("usuario"));
            input.SendKeys("pedroF");
            input = driver.FindElement(By.Id("clave"));
            input.SendKeys("1");
            IWebElement btn = driver.FindElement(By.Id("loguear"));
            btn.Click();
            test.Log(Status.Info, "llenar formularios de registro");


          //  agregar Usuario
            IWebElement linkUsuario = driver.FindElement(By.CssSelector("div.widget-small.primary.coloured-icon a[href='http://localhost/Sistema-de-biblioteca-basico-php-8-y-mysql/Usuarios']"));
            linkUsuario.Click();   
         
            
             IWebElement botonAgregar = driver.FindElement(By.CssSelector("button.btn.btn-primary.mb-2"));
            botonAgregar.Click();
       
            //llenar datos de nuevo usuario
            
            Thread.Sleep(1000);
            input = driver.FindElement(By.Id("usuario"));
            input.SendKeys("fulano");
            input = driver.FindElement(By.Id("nombre"));
            input.SendKeys("fulanito");
            input = driver.FindElement(By.Id("clave"));            
            input.SendKeys("1");
            input = driver.FindElement(By.Id("confirmar"));
            input.SendKeys("1");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement botonRegistrar = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnAccion")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", botonRegistrar);
            botonRegistrar.Click();
            test.Log(Status.Info, "Registro completado");
            

           // lista de usuarios
            var waits = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement botonPdfs = waits.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.btn.btn-danger")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", botonPdfs);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", botonPdfs);
            test.Log(Status.Info, "Lista de ususarios descargada");

           
        


            //Lista de Libros 
              IWebElement botonLibros = driver.FindElement(By.CssSelector("div.widget-small.info.coloured-icon a.info[href='http://localhost/Sistema-de-biblioteca-basico-php-8-y-mysql/Libros']"));
               botonLibros.Click();

               IWebElement botonPdf = driver.FindElement(By.CssSelector("button.btn.btn-danger"));
               ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", botonPdf);

            test.Log(Status.Info, "Lista de libros descargada");
            
             
         

        

   extent.Flush();



        }

    }
}
