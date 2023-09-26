using NUnit.Framework; 
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeuProjetoDeTeste
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(@"C:\Users\Eric Condé\ProjetoBase2\Driver", options);
        }

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl("https://mantis-prova.base2.com.br/login_page.php");

            IWebElement usernameField = driver.FindElement(By.Name("username"));
            

            usernameField.SendKeys("eric.conde");
            usernameField.Submit();

            IWebElement passwordField = driver.FindElement(By.Name("password"));
            passwordField.SendKeys("TesteMantis");

            passwordField.Submit();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(2500);
        }

        [Test]
        public void MyVisionTest()
        {
            LoginTest();

            IWebElement myVisionMenu = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[1]/a"));

            myVisionMenu.Click();
        }

        [Test]
        public void AllBugs()
        {
            LoginTest();

            IWebElement allBugs = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[2]"));

            allBugs.Click();
        }

        [Test]
        public void CreateBugs()
        {
            LoginTest();

            IWebElement createBugs = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[3]"));

            createBugs.Click();
        }

        [Test]
        public void Changes()
        {
            LoginTest();

            IWebElement changes = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[4]"));

            changes.Click();
        }

        [Test]
        public void Planning()
        {
            LoginTest();

            IWebElement planning = driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[5]"));

            planning.Click();
        }

        [Test]
        public void CollapseSidebar()
        {
            LoginTest();

            IWebElement collapse = driver.FindElement(By.Id("sidebar-btn"));

            collapse.Click();
        }

        [Test]
        public void SelectProject()
        {
            LoginTest();

            IWebElement dropdownProjects = driver.FindElement(By.Id("dropdown_projects_menu"));

            dropdownProjects.Click();

            IWebElement project = driver.FindElement(By.XPath("//*[@id='projects-list']/li[3]/div/ul/li[3]/a"));

            project.Click();
        }

        [Test]
        public void CreateNewBug()
        {
            CreateBugs();

            IWebElement dropdownFrequency = driver.FindElement(By.XPath("//*[@id='reproducibility']"));
            dropdownFrequency.Click();

            IWebElement frequency  = driver.FindElement(By.XPath("//*[@id='reproducibility']/option[1]"));
            frequency.Click();

            IWebElement dropdownGravity = driver.FindElement(By.XPath("//*[@id='severity']"));
            dropdownGravity.Click();

            IWebElement gravity = driver.FindElement(By.XPath("//*[@id='severity']/option[3]"));
            gravity.Click();

            IWebElement dropdownPriority = driver.FindElement(By.XPath("//*[@id='priority']"));
            dropdownPriority.Click();

            IWebElement priority = driver.FindElement(By.XPath("//*[@id='priority']/option[4]"));
            priority.Click();

            IWebElement summaryField = driver.FindElement(By.Id("summary"));
            summaryField.SendKeys("Teste de automação por Selenium");

            IWebElement descriptionField = driver.FindElement(By.Id("description"));
            descriptionField.SendKeys("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lobortis nibh sit amet consequat cursus. Sed egestas consectetur hendrerit. Aliquam vitae magna eu lectus efficitur maximus vitae ut magna. Integer nec nunc eu est scelerisque dapibus ac sit amet purus. Aliquam erat volutpat. Aenean nec mi lobortis, imperdiet nunc vitae, dictum lectus. Praesent efficitur odio mollis justo tincidunt consequat. Proin tristique, ex vel scelerisque posuere, dui purus pulvinar ante, a suscipit augue turpis in diam. Aenean euismod quis sapien id tempus. Nam lobortis sed odio eget sodales. Sed pellentesque scelerisque velit id pulvinar. Integer sed nunc dui. Mauris efficitur, libero eget tristique ornare, metus lorem vulputate nisi, vel maximus metus neque non enim. Suspendisse in erat sed dui eleifend vehicula.");

            IWebElement createBug = driver.FindElement(By.XPath("//*[@id='report_bug_form']/div/div[2]/div[2]/input"));
            createBug.Click();
        }

        [Test]
        public void SeeBugsFilters()
        {
            //Verificar os bugs de acordo com os filtros que forem selecionados, oque está setado é um exemplo
            AllBugs();

            IWebElement severityFilter = driver.FindElement(By.Id("show_severity_filter"));

            severityFilter.Click();

            Thread.Sleep(1500);

            IWebElement severityTarget = driver.FindElement(By.XPath("//*[@id='show_severity_filter_target']/select"));

            severityTarget.Click();

            Thread.Sleep(1500);

            string optionText = "texto";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"arguments[0].value = '{optionText}';", severityTarget);

            Thread.Sleep(1500);

            string targetValue = "Aplicar Filtro";
            IWebElement confirmFilters = driver.FindElement(By.CssSelector($"[value='{targetValue}']"));
            // IWebElement confirmFilters = driver.FindElement(By.Name("filter_submit"));

            confirmFilters.Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
